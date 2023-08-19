using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Cooperaciones
    {
            public int IdCooperacion { get; set; }
            public DateTime Fecha { get; set; }
            public string NoPedido { get; set; }
            public string Proveedor { get; set; }
            public string Descripcion { get; set; }
            public decimal Cantidad { get; set; }
            public decimal SubTotal { get; set; }
            public decimal Total { get; set; }
    }
}
