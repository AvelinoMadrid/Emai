using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class ColegiaturaModel
    {
        public int IdColegiatura { get; set; }
        public DateTime Fecha { get; set; }
        //public string NoPedido { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        //public decimal Subtotal { get; set; }
        //public decimal Total { get; set; }
    }

    public class ColegiaturaIDModel
    {
        public int IdColegiatura { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        //public decimal Subtotal { get; set; }
        //public decimal Total { get; set; }
    }

    public class ColegiaturaInsertarModel
    {
        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        //public decimal Subtotal { get; set; }
        //public decimal Total { get; set; }
    }

    public class ColegiaturaActualizarModel
    {
        public int IdColegiatura { get; set; }
        public DateTime Fecha { get; set; }
        //public string NoPedido { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        //public decimal Subtotal { get; set; }
        //public decimal Total { get; set; }
    }

    public class ColegiaturaEliminarModel
    {
        public int IdColegiatura { get; set; }
        public DateTime Fecha { get; set; }
        //public string NoPedido { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        //public decimal Subtotal { get; set; }
        //public decimal Total { get; set; }
    }
}
