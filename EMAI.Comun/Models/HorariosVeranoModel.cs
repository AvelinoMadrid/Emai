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
         
        public string Dia { get; set; }
        
        public string Hora { get; set; }


    }
    public class HorariosVeranoInsertModel
    {
        public string Dia { get; set; }
        public string Hora { get; set; }
    }

    public class HorariosVeranoUpModel
    {
        public int IdHorarioVerano { get; set; }    
        public string Dia { get; set; }
       
        public string Hora { get; set; }
    }




} // fin Namespace
