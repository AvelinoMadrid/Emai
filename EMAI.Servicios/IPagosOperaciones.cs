using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IPagosOperaciones
    {
        Task<List<PagosModel>> GetPagos();
        Task<PagosIDModel> GetPagosID(int IdPago);
        Task<bool> InsertarPagos(PagosInsertarModel value);

        Task<bool> ActualizarPagos(int IdPago, int IdPromosiones, int IdAdicionales, DateTime Fecha, string Folio, DateTime FechaPago,decimal SaldoPendiente, string Mes, int IdHorario, string Dia, int IdClase, int IdRecepcionista, decimal Costo, string Autorizacion,
            decimal Subtotal, decimal Iva, decimal Total);
        Task<bool> EliminarPago(int IdPago);
    }
}
