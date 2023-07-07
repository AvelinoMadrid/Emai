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
        public string Nombre { get; set; }
        public string CNormal { get; set; }
        public string CVerano { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }
        public string Dia2 { get; set; }
        public string Horario2 { get; set; }
        public string Dia3 { get; set; }
        public string Horario3 { get; set; }
        public decimal Costo { get; set; }
        public string ClaseOpc { get; set; }
        public string HorarioOpc { get; set; }
        public string DiaOpc { get; set; }

        public List<Clase> Lista { get; set; }
    }
}
