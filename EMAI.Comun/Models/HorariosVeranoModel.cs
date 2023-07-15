using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class HorariosVeranoModel
    {
        public int IdHorarioVerano { get; set; }
        public int IdAlumno { get; set; }
        public int IdMaestro { get; set;}
        public int IdClase { get; set; }
        public string Dia { get; set; } 
        public DateTime Fecha { get; set; }
    }

    public class HorariosVeranoInsertModel
    {
        public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string Dia { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class HorariosVeranoUpModel
    {
        public int IdHorarioVerano { get; set; }
        public string Fecha { get; set; }
    }




} // fin Namespace
