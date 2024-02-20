using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class HorarioVerano
    {
        public int IdHorarioVerano { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public List<HorarioVerano> Lista { get; set; }

        public string Hora { get; set; }

        public string NombreMaestro { get; set; }
        public string NombreClase { get; set; }

        public List<Maestro> MaestrosDisponibles { get; set; }
        public List<Clase> ClasesDisponibles { get; set; }
    }
}
