using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IGastosDiaOperaciones
    {
        Task<List<GastosDiaModel>> GetGastosDia();
        Task<GastosDiaIDModel> GetGastosDiaID(int IdGastoDia);
        Task<bool> InsertarGastosDia(GastosDiaInsertarModel value);
        Task<bool> ActualizarGastosDia(int IdGastoDia, DateTime Fecha, string NoPedido, string Proveedor, decimal Cantidad);
        Task<bool> EliminarGastosDia(int IdGastoDia);

    }
}
