using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class DotacionDia
    {
        public int IdDotacion { get; set; }
        public string Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public List<DotacionDia> Lista { get; set; }
    }
}
