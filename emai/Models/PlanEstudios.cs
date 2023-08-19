using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class PlanEstudios
    {
        public string Nombre { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }
        public string HorarioVerano { get; set; }
        public decimal Costo { get; set; }
        public List<PlanEstudios> Lista { get; set; }
    }
}
