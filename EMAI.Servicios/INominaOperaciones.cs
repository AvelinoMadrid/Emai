using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface INominaOperaciones
    {
 
        Task<List<NominaModel>> GetAllNomina();
        Task<NominaModel> GetByIDNomina(int id);
        Task<bool> InsertarNomina(InsertNominaModel value);
        Task<bool> ActualizarNomina(int IdNomina,DateTime Fecha, string NoPedido, string Proveedor, string Descripcion, decimal Cantidad, decimal Subtotal, decimal Total);
        Task<bool> EliminarNomina(int id);

    }
}
