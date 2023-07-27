using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class EventosModel
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
    }

    public class EventosIDModel
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
    }

    public class EventoInsertarModel
    {
        public string NombreEvento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
    }

    public class EventosActualizarModel
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
    }

    public class EventosEliminarModel
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
    }
}
