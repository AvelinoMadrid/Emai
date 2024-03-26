using AutoMapper;
using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using EMAI.Servicios;
using Email.Utiilities.Static;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace EMAI.LND
{
    public class AlumnosOperaciones : IAlumnosOperaciones
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;


        public AlumnosOperaciones(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> RegisterAlumno(AlumnoRequest request)
        {
            var response = new BaseResponse<bool>();

            using var db = AppRepositoryFactory.GetAppRepository();

            var newAlumno = _mapper.Map<InsertarAlumnoModelV1>(request);


            response.Data = await db.InsertarAlumnoTwo(newAlumno);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = StaticVariable.MESSAGE_SAVE;

            }
            else
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_FALLED;
            }
            return response;
        }

        public async Task<bool> verificarExistFolio(string folio)
        {

            bool response = false;
            using var db = AppRepositoryFactory.GetAppRepository();
            //recorrer el array
            var lista = await db.GetListFolio();
            int countList = lista.Length;
            for (int i = 0; i < countList; i++)
            {
                if (lista[i].Folio.Equals(folio))
                    response = true;
                break;
            }
            return response;
        }

        public async Task<ListFolioResponse> FolioGenerate()
        {
            var response = new ListFolioResponse();
            const string prefijo = "EMAI-";
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            using (var crpto = new RNGCryptoServiceProvider())
            {
                try
                {
                    var countChars = _config.GetValue<int>("StringFolio:CountString");
                    var bytesArray = new byte[countChars];
                    crpto.GetBytes(bytesArray);

                    var result = new char[countChars];
                    var validCharCount = validChars.Length;

                    for (int i = 0; i < countChars; i++)
                    {
                        var indice = bytesArray[i] % validCharCount;
                        result[i] = validChars[indice];
                    }

                    response.Folio = prefijo + new string(result);
                    return response;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo Problema en el Folio", ex);
                }
            }
        }
        public async Task<BaseResponse<List<SelectClasesHorarioResponse>>> SelectListClaseHorarioV1(int idClase)
        {
            string nameprocedure = _config.GetValue<string>("NameProcedure:SelectListHorarioVista");

            var response = new BaseResponse<List<SelectClasesHorarioResponse>>();

            try
            {
                using var db = AppRepositoryFactory.GetAppRepository();
                var dataList = await db.SelectClasesHorario(nameprocedure, idClase);

                if (dataList != null)
                {
                    response.IsSuccess = true;
                    response.Data = dataList;
                    response.Message = StaticVariable.MESSAGE_QUERY;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = StaticVariable.MESSAGE_FALLED;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<List<AlumnoResponseV1>>> GetListaAlumnoV1()
        {
            var response = new BaseResponse<List<AlumnoResponseV1>>();
            using var db = AppRepositoryFactory.GetAppRepository();
            var data = await db.GetListAlumnosTotalV1();


            if (data != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<List<AlumnoResponseV1>>(data);

                response.Message = StaticVariable.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_FALLED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> ReactivarByIdAlumnoV1(int IdAlumno)
        {
            var response = new BaseResponse<bool>();
            using var db = AppRepositoryFactory.GetAppRepository();

            var alumnoById = await GetAlumnosByIdV1(IdAlumno);

            if (alumnoById != null)
            {
                response.Data = await db.ReactivarByIdAlumnoV1(IdAlumno);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = StaticVariable.MESSAGE_REACTIVE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = StaticVariable.MESSAGE_FALLED;
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_FALLED;
            }
            return response;
        }


        public async Task<BaseResponse<bool>> DeleteByIdAlumnoV1(int IdAlumno)
        {
            var response = new BaseResponse<bool>();
            using var db = AppRepositoryFactory.GetAppRepository();

            var alumnoById = await GetAlumnosByIdV1(IdAlumno);

            if (alumnoById != null)
            {
                response.Data = await db.DeleteByIdAlumnoV1(IdAlumno);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = StaticVariable.MESSAGE_DELETE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = StaticVariable.MESSAGE_FALLED;
                }

            }
            else
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_FALLED;
            }
            return response;
        }

        public async Task<BaseResponse<AlumnoResponseV1>> GetAlumnosByIdV1(int IdAlumno)
        {
            var response = new BaseResponse<AlumnoResponseV1>();

            using var db = AppRepositoryFactory.GetAppRepository();

            var AlumnoById = await db.GetListAlumnoByIdV1(IdAlumno);

            if (AlumnoById != null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<AlumnoResponseV1>(AlumnoById);
                response.Message = StaticVariable.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_QUERY_EMPATY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> EditarAlumnoV1(int IdAlumno, AlumnoRequestV1 request)
        {
            var response = new BaseResponse<bool>();
            using var db = AppRepositoryFactory.GetAppRepository();

            var dataAlumno = await GetAlumnosByIdV1(IdAlumno);

            if (dataAlumno.Data != null)
            {
                var dataUpdate = _mapper.Map<InsertarAlumnoModelV1>(request);
                dataUpdate.IdAlumno = IdAlumno;
                response.Data= await db.EditarAlumnoV1(dataUpdate);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = StaticVariable.MESSAGE_UPDATE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = StaticVariable.MESSAGE_FALLED;
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_QUERY_EMPATY;
            }
            return response;
        }
    }

}

