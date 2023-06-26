using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class CooperacionesModel
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

    public class InsertCooperacionModel
    {
       
        public DateTime Fecha { get; set; }
        public string NoPedido { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }

    public class UpdateCooperacionesModel
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
