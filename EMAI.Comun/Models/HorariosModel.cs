using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class HorariosModel
    {
        public int IdHorario { get; set; }
        //public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }

    public class HorariosIDModel
    {
        public int IdHorario { get; set; }
        //public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }

    public class HorariosInsertarModel
    {
        //public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }

    public class HorariosActualizarModel
    {
        public int IdHorario { get; set; }
        //public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }

    public class HorariosEliminarModel
    {
        public int IdHorario { get; set; }
        //public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}
