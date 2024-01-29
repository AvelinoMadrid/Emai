using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public int IdHora { get; set; }
        public string NameHora { get; set; }
        public string Fecha { get; set; }
        public string NombreEvento { get; set; }
    }
}
