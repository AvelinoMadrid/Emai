using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Horario
    {
        public int IdHorario { get; set; }
        //public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public List<Horario> Lista { get; set; }

    }
}
