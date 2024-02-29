using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class NominaModel
    {
        public int IdNomina { get; set; }   
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        //public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        //public decimal Subtotal { get; set; }
        //public decimal Total { get; set; }  
    }

    public class InsertNominaModel
    {
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        //public string Descripcion { get; set; }
        public decimal Cantidad { get;set; }
        //public decimal SubTotal { get; set; }
        //public decimal Total { get; set; }
    }

    public class UpdateNominaModel
    {
        public int IdNomina { get; set; }
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        //public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        //public decimal Subtotal { get; set; }
        //public decimal Total { get; set; }
    }



}
