using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.DTOS.Dtos.Request
{
    public class AlumnoRequest
    {
        public int IdClase { get; set; }
        public DateTime FechaInscripcion { get; set; } // 1
        public string Tag { get; set; } // 2
        public int NoDiaClases { get; set; } // 3
        public DateTime FechaInicioClaseGratis { get; set; } //4
        public string Nombre { get; set; } // 8
        public int Edad { get; set; } //9
        public DateTime FechaNacimiento { get; set; } //9
        public string TelefonoCasa { get; set; } // 10
        public string Celular { get; set; } // 11
        public string Facebook { get; set; } // 12
        public string Email { get; set; } // 13
        public string Enfermedades { get; set; } // 14 
        public string InstrumentoBase { get; set; } //5
        public string Dia { get; set; }  // 6
        public string InstrumentoOpcional { get; set; } // 7
        public string DiaOpcio { get; set; }
    }
}
