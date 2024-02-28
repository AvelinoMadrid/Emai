using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.DTOS.Dtos.Base;
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

        public AlumnosOperaciones(IConfiguration config)
        {
            _config = config;
        }

        //MOSTRAR
        public async Task<List<AlumnosModel>> GetAlumnos()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAlumnos();
            return rsp;
        }

        public async Task<ObtenerAlumno> GetAlumnosbyID(int id) 
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAlumnosbyID(id);
            return rsp; 
        }

        public async Task<bool> InsertarAlumno(InsertAlumnoModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarAlumno(value);
            return rsp;
        }

        //ELIMINAR
        public async Task<bool> DeleteByIdAlumno(int Id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.DeleteByIdAlumno(Id);
            return rsp;
        }

        // ACTUALIZAR ALUMNO 
        public async Task<bool> UpdateAlumnos(int IdAlumno, int IdClase, string Tag, int NoDiaClases, DateTime FechaInicioClaseGratis, DateTime FechaFinClaseGratis, string Nombre, string ApellidoP, string ApellidoM,int Edad, DateTime FechaNacimiento, string TelefonoCasa, string Celular, string Facebook, string Email, string Enfermedades, bool Discapacidad, string InstrumentoBase, string Dia,string Hora, string InstrumentoOpcional, string DiaOpcional, string HoraOpcional, string CelularPapas, string EmailPapas, string RecogerPapas, string CelularTR, string NumEmergencia)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.UpdateAlumnos(IdAlumno, IdClase, Tag, NoDiaClases, FechaInicioClaseGratis,FechaFinClaseGratis, Nombre,  ApellidoP,  ApellidoM,  Edad,  FechaNacimiento,  TelefonoCasa, Celular,  Facebook,  Email,  Enfermedades,  Discapacidad,  InstrumentoBase,  Dia,  Hora,  InstrumentoOpcional,  DiaOpcional,  HoraOpcional, CelularPapas,  EmailPapas, RecogerPapas, CelularTR, NumEmergencia);
            return rsp;
        }

       

        // prueba para obtener alumnos por ID 

        public async Task<AlumnosbyIDModel> ObtenerAlumnosporID(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ObtenerAlumnosporID(id);
            return rsp;
            
        }

        // nuevos requirimintos

        public async Task<bool> InsertarAlumnosParteI(AlumnosNuevo value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarAlumnosParteI(value);
            return rsp;
        }

        public async Task<bool> InsertarPapas(PapasNuevo value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarPapas(value);
            return rsp;
        }

        public async Task<bool> InsertarEstudios(EstudiosNuevo value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarEstudios(value); 
            return rsp;
        }

        public async Task<bool> InsertarConocimientosMusicales(ConocimientosMusicales value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarConocimientosMusicales(value);
            return rsp;
        }

        public async Task<bool> InsertarHobbys(Hoobys value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarHobbys( value);
            return rsp;
        }

        public Task<bool> InsertarAlumno(InsertarAlumnoModelV1 value)
        {
            throw new NotImplementedException();
        }


        public async Task<BaseResponse<bool>> RegisterAlumno(InsertarAlumnoModelV1 request)
        {
            var response = new BaseResponse<bool>();

            using var db = AppRepositoryFactory.GetAppRepository();
            response.Data = await db.InsertarAlumnoTwo(request);

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
                int countList= lista.Length;
                for (int i = 0; i < countList; i++)
                {
                    if (lista[i].Folio.Equals(folio))
                        response=true;
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
                    
                     response.Folio=prefijo + new string(result);
                    return response;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo Problema en el Folio", ex);
                }
            }
        }


        //public async Task<BaseResponse<bool>> RegisterAlumno(InsertarAlumnoModelTwo request)
        //{
        //    var response = new BaseResponse<bool>();

        //    using var db = AppRepositoryFactory.GetAppRepository();
        //    response.Data= await db.InsertarAlumnoTwo(request);

        //    if (response.Data)
        //    {
        //        response.IsSuccess= true;
        //        response.Message = StaticVariable.MESSAGE_SAVE;

        //    }
        //    else
        //    {
        //        response.IsSuccess= false;
        //        response.Message = StaticVariable.MESSAGE_FALLED;
        //    }
        //    return response;
    }

    }



