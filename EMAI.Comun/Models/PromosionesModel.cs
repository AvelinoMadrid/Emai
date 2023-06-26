using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class PromosionesModel
    {
        public int IdPromosion { get; set; }
        public int IdAlumno { get; set; }
        public int Porcentaje { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PromosionesIDModel
    {
        public int IdPromosion { get; set; }
        public int IdAlumno { get; set; }
        public int Porcentaje { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PromosionesInsertarModel
    {
        public int IdAlumno { get; set; }
        public int Porcentaje { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PromosionesActualizarModel
    {
        public int IdPromosion { get; set; }
        public int IdAlumno { get; set; }
        public int Porcentaje { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PromosionesEliminarModel
    {
        public int IdPromosion { get; set; }
        public int IdAlumno { get; set; }
        public int Porcentaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}
