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
        // dia normal de clase 
        public string Dia { get; set; }


        // segundo dia
        public string Dia2 { get; set; }


        // tercer dia
        public string Dia3 { get; set; }

        public decimal Costo { get; set; }


        public string ClaseOpc { get; set; }
        // dia opcional 
        public string HorarioOpc { get; set; }

        public string NombreHorario { get; set; }

        public ICollection<Alumnos> Alumnos { get; set; }

        public List<Horario> HorarioDisponibles { get; set; }
        public List<Clase> Lista { get; set; }
    }
}
