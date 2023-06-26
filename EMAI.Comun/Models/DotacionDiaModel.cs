using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public  class DotacionDiaModel
    {
        public int IdDotacion { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

    }

    public class InsertDotacionDiaModel
    {
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }

    public class UpdateDotacionModel
    {
        public int IdDotacion { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }



}
