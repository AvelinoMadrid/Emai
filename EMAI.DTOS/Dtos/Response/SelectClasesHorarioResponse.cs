using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.DTOS.Dtos.Response
{
    public class SelectClasesHorarioResponse
    {
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
        public string Dia { get; set; }
    }
}
