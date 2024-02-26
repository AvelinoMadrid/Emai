using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Request;
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
        //Task<bool> ActualizarPromosiones(int IdPromosion, int IdAlumno, int Porcentaje, DateTime Fecha);
        //Task<bool> EliminarPromosiones(int IdPromosiones);
       

    }
}
