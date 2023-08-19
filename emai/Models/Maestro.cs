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
        //public int IdClase { get; set; }
        //public int IdHorario { get; set; }
        //public int IdAlumno { get; set; }
        public bool Status { get; set; }
        //public bool Base { get; set; }
        //public string Suplente { get; set; }
        public decimal Pago { get; set; }

        public string StatusSeleccionado { get; set; }

        public List<Maestro> Lista { get; set; }
    }
}
