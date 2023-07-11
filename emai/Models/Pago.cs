using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdPromosiones { get; set; }
        public int IdAdicionales { get; set; }
        public DateTime Fecha { get; set; }
        public string Folio { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string Mes { get; set; }
        public int IdHorario { get; set; }
        public string Dia { get; set; }
        public int IdClase { get; set; }
        public int IdRecepcionista { get; set; }
        public decimal Costo { get; set; }
        public string Autorizacion { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public List<Pago> Lista { get; set; }
    }
}
