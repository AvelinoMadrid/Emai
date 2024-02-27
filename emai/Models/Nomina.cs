using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Nomina
    {
        public int IdNomina { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public List<Nomina> Lista { get; set; }
    }
}
