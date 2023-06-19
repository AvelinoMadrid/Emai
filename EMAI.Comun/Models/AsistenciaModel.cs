using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{

    // obtener Asistencias 
    public class AsistenciaModel
    {

        public int IdAsistencia { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public bool Asistecia { get; set; }

    }

    // insertar Asistencia
    public class InsertAsistenciaModel
    {
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public bool Asistecia { get; set; }
    }

    public class UpdateAsistenciaModel
    {
        public int IdAsistencia { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public bool Asistecia { get; set; }
    }


}
