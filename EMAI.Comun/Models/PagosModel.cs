using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class PagosModel
    {
        public int IdPago { get; set; }
        public string Folio { get; set; } 
        //public DateTime FechaPago { get; set; } 
        public int IdPromosionales { get; set; } 
        public string Mes { get; set; } 
        public int IdClasePago { get; set; } 
        public int IdHorario { get; set; }
        public string DiaAlumnoPago { get; set; } 
        public string InstrumentoAlimnoPago { get; set; } 
        public decimal CostoLibro { get; set; } 
        public string NombreLibro { get; set; } 
        //public string Atendio { get; set; } 
        public decimal Costo { get; set; } 
        public decimal Subtotal { get; set; } 
        public decimal IVA { get; set; } 
        public decimal Total { get; set; } 
        public int IdAlumno { get; set; }

    }

    public class PagosIDModel
    {
        public int IdPago { get; set; }
        public string Folio { get; set; }
        //public DateTime FechaPago { get; set; } 
        public int IdPromosionales { get; set; }
        public string Mes { get; set; }
        public int IdClasePago { get; set; }
        public int IdHorario { get; set; }
        public string DiaAlumnoPago { get; set; }
        public string InstrumentoAlimnoPago { get; set; }
        public decimal CostoLibro { get; set; }
        public string NombreLibro { get; set; }
        //public string Atendio { get; set; } 
        public decimal Costo { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public int IdAlumno { get; set; }
    }

    public class PagosInsertarModel
    {
        
        public string Folio { get; set; }
        //public DateTime FechaPago { get; set; } 
        public int IdPromosionales { get; set; }
        public string Mes { get; set; }
        public int IdClasePago { get; set; }
        public int IdHorario { get; set; }
        public string DiaAlumnoPago { get; set; }
        public string InstrumentoAlimnoPago { get; set; }
        public decimal CostoLibro { get; set; }
        public string NombreLibro { get; set; }
        //public string Atendio { get; set; } 
        public decimal Costo { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public int IdAlumno { get; set; }
    }
}

    public class PagosActualizarModel
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
    }

    public class PagosEliminarModel
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
    }


