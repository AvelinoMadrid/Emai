using AutoMapper;
using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using EMAI.LND.Validators;
using EMAI.Servicios;
using Email.Utiilities.Static;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class Programa5sOperaciones : IPrograma5sOperaciones
    {
        private readonly IConfiguration _config;
        private readonly IContendorImagenes _contendorImagenes;
        private readonly IMapper _mapper;
        private readonly Programa5sValidators _validators;

        public Programa5sOperaciones(IConfiguration config, IMapper mapper, Programa5sValidators validators, IContendorImagenes contendorImagenes)
        {
            this._config = config;
            this._mapper = mapper;
            _validators = validators;
            _contendorImagenes = contendorImagenes;
        }
        //metodo asincroniuco para insertar
        public async Task<BaseResponse<bool>> RegisterProgramV1(Programas5Request request)
        {
            var response = new BaseResponse<bool>();
            string dataUrl = "";
            string dataUr2 = "";
            string nameProcedure = _config.GetValue<string>("NameProcedure:InsertProgram5sv1");

            try
            {
                //toda la logica posible para su inseccion
                using var db = AppRepositoryFactory.GetAppRepository();
               // var validatorsResult = await _validators.ValidateAsync(request);

                //if(!validatorsResult.IsValid)
                //{
                //    response.IsSuccess = false;
                //    response.Message = StaticVariable.MESSAGE_VALIDATE;
                //    response.Errors = validatorsResult.Errors;
                //    return response;
                //}
                //if(request.ImagenAntes!=null)
                //{

                //}

                var newPrograma = _mapper.Map<Programa5ModelV1>(request);

                if(request.ImagenAntes!=null)
                {
                    dataUrl = await GuadarFoto(request.ImagenAntes);
                    newPrograma.ImagenAntes = dataUrl;
                }
                if (request.ImagenDespues != null)
                {
                    dataUr2 = await GuadarFoto(request.ImagenDespues);
                    newPrograma.ImagenDespues = dataUr2;
                }
                response.Data= await db.InsertarPrograma5sV1(nameProcedure, newPrograma);

                if (response.Data)
                {
                    response.Data = true;
                    response.Message= StaticVariable.MESSAGE_SAVE;
                }else
                {
                    response.Data = false;
                    response.Message = StaticVariable.MESSAGE_FALLEDV1;
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = StaticVariable.MESSAGE_NOT_DATABASE;
            }
            return response;    
        }
        public async Task<string> GuadarFoto(IFormFile picture)
        {
            string response = "";

            using var stream = new MemoryStream();
            await picture.CopyToAsync(stream);
            //Task<BaseResponse<string>> GuadarImagen(byte[] file,string contentType,string container,string extension,string name);
            var fileBytes = stream.ToArray();

            response = await _contendorImagenes.GuadarImagen
                                    (fileBytes,picture.ContentType,Path.GetExtension(picture.FileName),
                                    StaticVariable.Contenedor_Imagenes,Guid.NewGuid().ToString());

            return response;
        }

        //Mostrar todo
        public async Task<List<Programa5sModel>> GetPrograma5s()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetPrograma5s();
            return rsp;
        }

        //Mostrar por ID
        public async Task<Programa5sIdModel> GetPrograma5sId(int Id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetPrograma5sId(Id);
            return rsp;
        }
        public async Task<BaseResponse<Programas5Response>> GetPrograma5sById(int IdPrograma)
        {
            var response = new BaseResponse<Programas5Response>();

            try
            {
                string nameProcedure = _config.GetValue<string>("NameProcedure:SelectByIdPrograma5Sv1");
                using var db = AppRepositoryFactory.GetAppRepository();
                var programaById= await db.GetPrograma5sById(nameProcedure,IdPrograma);

                if(programaById !=null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<Programas5Response>(programaById);
                    response.Message = StaticVariable.MESSAGE_QUERY;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message= StaticVariable.MESSAGE_QUERY_EMPATY;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_NOT_DATABASE;
            }
            return response;
        }

        //Insertar un Programa5s
        public async Task<bool> InsertarPrograma5s(Programa5sInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarPrograma5s(value);
            return rsp;
        }

        //Actualizar un Programa 5s
        public async Task<bool> ActualizarPrograma5s(int Id, string Area, string Supervisor, DateTime FechaAntes, DateTime FechaInicio, string Detalles)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarPrograma5s(Id, Area, Supervisor, FechaAntes, FechaInicio, Detalles);
            return rsp;
        }

        public async Task<BaseResponse<List<Programas5Response>>> GetAllProgramaV1()
        {
             var response = new BaseResponse<List<Programas5Response>>();
            try
            {
                string nameProcedure = _config.GetValue<string>("NameProcedure:SelectAllPrograma5Sv1");
                using var db = AppRepositoryFactory.GetAppRepository();
                var listData = await db.GetAllPrograma5sV1(nameProcedure);

                if(listData != null) {
                    response.IsSuccess= true;
                    response.Data = _mapper.Map<List<Programas5Response>>(listData);
                    response.Message=StaticVariable.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSuccess= false;
                    response.Message = StaticVariable.MESSAGE_FALLED;
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

   
    }
}
