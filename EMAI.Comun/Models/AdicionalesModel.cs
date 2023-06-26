using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class AdicionalesModel
    {
        public int IdAdicional { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class AdicionalesIDModel
    {
        public int IdAdicional { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class AdicionalesInsertarModel
    {
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class AdicionalesActualizarModel
    {
        public int IdAdicional { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class AdicionalesEliminarModel
    {
        public int IdAdicional { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
