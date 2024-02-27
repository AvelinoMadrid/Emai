using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IPromosionesOperaciones
    {
        //Task<List<PromosionesModel>> GetPromosiones();
        //Task<PromosionesIDModel> GetPromosionesID(int IdPromosiones);
        //Task<bool> InsertarPromosiones(PromosionesInsertarModel value);
        Task<BaseResponse<bool>> InsertarPromocionesV1(PromocionesRequest request);
        Task<BaseResponse<List<PromocionResponseV1>>> ListPromocionesV1();
        Task<BaseResponse<List<PromocionResponseSelectV1>>> ListSelectPromocionesV1();
        Task<BaseResponse<PromocionResponseV1>> PromocionById(int IdPromocion);
        Task<BaseResponse<bool>> DeletePromocion(int IdPromocion);
        Task<BaseResponse<bool>> UpdatePromocion(int IdPromocion, PromocionesRequest request);
        //Task<bool> ActualizarPromosiones(int IdPromosion, int IdAlumno, int Porcentaje, DateTime Fecha);
        //Task<bool> EliminarPromosiones(int IdPromosiones);


    }
}
