using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class GastosDiaModel
    {
        public int IdGastoDia { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }

    public class GastosDiaIDModel
    {
        public int IdGastoDia { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }

    public class GastosDiaInsertarModel
    {
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }

    public class GastosDiaActualizarModel
    {
        public int IdGastoDia { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }

    public class GastosDiaEliminarModel
    {
        public int IdGastoDia { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
