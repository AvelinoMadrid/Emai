using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface ICooperacionesOperaciones
    {
        Task<List<CooperacionesModel>> GetAllCooperaciones();
        Task<CooperacionesModel> GetCooperacionesByID(int id);
        Task<bool> InsertarCooperaciones(InsertCooperacionModel value);
        Task<bool> DeleteCooperacionesbyId(int id);
        Task<bool> UpdateCooperaciones(int id, DateTime Fecha, string NoPedido, string Proveedor,  decimal cantidad, string img);


    }
}
