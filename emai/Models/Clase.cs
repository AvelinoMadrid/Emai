using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace emai.Models
{
    public class Clase
    {
        public int idClase { get; set; }

        public int idHorario { get; set; }
        public string Nombre { get; set; }
        public string CNormal { get; set; }
        public string CVerano { get; set; }
        public string Dia { get; set; }

        public string Dia2 { get; set; }


        public string Dia3 { get; set; }

        public decimal Costo { get; set; }


        public string ClaseOpc { get; set; }

        public string HorarioOpc { get; set; }

        public string NombreHorario { get; set; }

        public ICollection<Alumnos> Alumnos { get; set; }

        public List<Horario> HorarioDisponibles { get; set; }
        public List<Clase> Lista { get; set; }
    }
}
