using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Maestro
    {
        public int IdMaestro { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Estatus { get; set; }
        public decimal Pago { get; set; }
        public decimal PagoSemanal { get; set; }
        public decimal PagoHora { get; set; }
        public string StatusSeleccionado { get; set; }
        public string Area { get; set; }
        public List<Maestro> Lista { get; set; }
    }
}
