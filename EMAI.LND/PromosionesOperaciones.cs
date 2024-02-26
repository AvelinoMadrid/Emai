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
        public async Task<BaseResponse<bool>> InsertarPromocionesV1(PromocionesRequest request)
        {
            var response = new BaseResponse<bool>();
            using var db = AppRepositoryFactory.GetAppRepository();//cxhecar y mandarlo a inyeccion
            
            var newPromocion = _mapper.Map<PromocionesModel>(request);///mapearlo 
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

        public Task<BaseResponse<List<PromocionesResponseV1>>> ListAllPromociones()
        {
            var response = new BaseResponse<List<PromocionesResponseV1>>();
            using var db = AppRepositoryFactory.GetAppRepository();
            var listPromociones=db.GetAllPromociones();

            if(listPromociones is not null)
            {
                response.IsSuccess= true;
                response.Data = _mapper.Map<List<PromocionesResponseV1>>(listPromociones);
                response.Message= StaticVariable.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = StaticVariable.MESSAGE_FALLED;

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
