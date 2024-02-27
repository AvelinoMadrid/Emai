using AutoMapper;
using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using EMAI.Servicios;
using Email.Utiilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class PromosionesOperaciones : IPromosionesOperaciones
    {
        public readonly IMapper _mapper;
        public readonly IAppRepository _repositoy;

        public PromosionesOperaciones(IMapper mapper)
        {
            _mapper = mapper;
           // _repositoy = repositoy;
        }

        public async Task<BaseResponse<bool>> DeletePromocion(int IdPromocion)
        {
           var response=new BaseResponse<bool>();
            using var db = AppRepositoryFactory.GetAppRepository();//cxhecar y mandarlo a inyeccion

            var promocionById = await PromocionById(IdPromocion);
            if (promocionById.Data != null)
            {
                response.Data = await db.EliminarPromocionesV1(IdPromocion);

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
                response.IsSuccess = true;
                response.Message = StaticVariable.MESSAGE_QUERY_EMPATY;
            }
            return response;

    
        }

        public async Task<BaseResponse<bool>> InsertarPromocionesV1(PromocionesRequest request)
        {
            var response = new BaseResponse<bool>();
            using var db = AppRepositoryFactory.GetAppRepository();//cxhecar y mandarlo a inyeccion
            
            var newPromocion = _mapper.Map<PromocionesModelV1>(request);
            response.Data = await db.InsertarPromocionesV1(newPromocion);
            //response.Data = await db.InsertarPromocionesV1(newPromocion);

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

        public async Task<BaseResponse<List<PromocionResponseV1>>> ListPromocionesV1()
        {
            var response = new BaseResponse<List<PromocionResponseV1>>();
            using var db = AppRepositoryFactory.GetAppRepository();

            var listEntity = await db.GetPromocionesV1();

            if(listEntity!=null)
            {
                response.IsSuccess= true;
                response.Data= _mapper.Map<List<PromocionResponseV1>>(listEntity);
                response.Message = StaticVariable.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_FALLED;
            }
            return response;
        }

        public async Task<BaseResponse<List<PromocionResponseSelectV1>>> ListSelectPromocionesV1()
        {
            try
            {
                var response = new BaseResponse<List<PromocionResponseSelectV1>>();
                using var db = AppRepositoryFactory.GetAppRepository();

                var listEntity = await db.GetPromocionesV1();

                if (listEntity != null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<List<PromocionResponseSelectV1>>(listEntity);
                    response.Message = StaticVariable.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = StaticVariable.MESSAGE_FALLED;
                }
                return response;

            }
            catch(Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }
        }

        public async Task<BaseResponse<PromocionResponseV1>> PromocionById(int IdPromocion)
        {
            var reponse =new  BaseResponse<PromocionResponseV1>();
            using var db = AppRepositoryFactory.GetAppRepository();
            var promocionV1 = await db.GetPromocionById(IdPromocion);

            if(promocionV1 != null)
            {
                reponse.IsSuccess = true;
                reponse.Data = _mapper.Map<PromocionResponseV1>(promocionV1);
                reponse.Message = StaticVariable.MESSAGE_QUERY;
            }
            else
            {
                reponse.IsSuccess= false;
                reponse.Message = StaticVariable.MESSAGE_QUERY_EMPATY;
            }
            return reponse;
            
        }

        public async Task<BaseResponse<bool>> UpdatePromocion(int IdPromocion, PromocionesRequest request)
           {
            var response = new BaseResponse<bool>();
            using var db = AppRepositoryFactory.GetAppRepository();


            var promocionData = await PromocionById(IdPromocion);
            if(promocionData.Data != null)
            {
                var dataUpdate = _mapper.Map<PromocionesModelV1>(request);
                dataUpdate.IdPromociones = IdPromocion;
                response.Data = await db.UpdatePromocionesV1(dataUpdate);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message= StaticVariable.MESSAGE_UPDATE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = StaticVariable.MESSAGE_FALLED;
                }

            }
            else
            {
                response.IsSuccess = true;
                response.Message = StaticVariable.MESSAGE_QUERY_EMPATY;

            }
            return response;
        }




        //Mostrar todo
        //public async Task<List<PromosionesModel>> GetPromosiones()
        //{
        //    using var db = AppRepositoryFactory.GetAppRepository();
        //    var rsp = await db.GetPromosiones();
        //    return rsp;
        //}

        ////Mostrar por ID
        //public async Task<PromosionesIDModel> GetPromosionesID(int IdPromosiones)
        //{
        //    using var db = AppRepositoryFactory.GetAppRepository();
        //    var rsp = await db.GetPromosionesID(IdPromosiones);
        //    return rsp;
        //}

        ////Insertar un Promosiones
        //public async Task<bool> InsertarPromosiones(PromosionesInsertarModel value)
        //{
        //    using var db = AppRepositoryFactory.GetAppRepository();
        //    var rsp = await db.InsertarPromosiones(value);
        //    return rsp;
        //}

        ////Actualizar Promosiones
        //public async Task<bool> ActualizarPromosiones(int IdPromosion, int IdAlumno, int Porcentaje, DateTime Fecha)
        //{
        //    using var db = AppRepositoryFactory.GetAppRepository();
        //    var rsp = await db.ActualizarPromosiones(IdPromosion, IdAlumno, Porcentaje, Fecha);
        //    return rsp;
        //}

        ////Eliminar Promosiones
        //public async Task<bool> EliminarPromosiones(int IdPromosion)
        //{
        //    using var db = AppRepositoryFactory.GetAppRepository();
        //    var rsp = await db.EliminarPromosiones(IdPromosion);
        //    return rsp;
        //}


    }
}
