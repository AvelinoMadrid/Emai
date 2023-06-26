using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IDotacionDiaOperaciones
    {
        Task<List<DotacionDiaModel>> GetAllDotacionDia();
        Task<DotacionDiaModel> GetDotacionDiaById(int id);
        Task<bool> InsertarDotacionDia(InsertDotacionDiaModel value);
        Task<bool> UpdateDotacionDia(int id,DateTime fecha, string NoPedido, string Descripcion, decimal cantidad, decimal subtotal, decimal Total);
        Task<bool> DeleteDotacionDiabyID(int id);
    }
}
