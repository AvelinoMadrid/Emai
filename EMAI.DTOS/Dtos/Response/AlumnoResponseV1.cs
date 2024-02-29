using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.DTOS.Dtos.Response
{
    public class AlumnoResponseV1
    {
        public int IdAlumno { get; set; }
        public string FechaInscripcion { get; set; }
        public string Tag { get; set; } = null!;
        public int NoDiaClases { get; set; }
        public string FechaInicioClase { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int Edad { get; set; }
        public string FechaNacimiento { get; set; }
        public string TelefonoCasa { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Enfermedades { get; set; } = null!;
        public int SeleccionarClase1 { get; set; }
        public string DiaAndHoraClase { get; set; } = null!;
        public int SeleccionarClase2 { get; set; }
        public string DiaAndHoraClaseOpcional { get; set; } = null!;

        public string NombrePapas { get; set; } = null!;
        public string CelularPapas { get; set; } = null!;
        public string EmailPapas { get; set; } = null!;
        public string TutorRecoger { get; set; } = null!;
        public string CelularTR { get; set; } = null!;
        public string NumEmergencia { get; set; } = null!;

        public string Estudios { get; set; }
        public string EscuelaActuales { get; set; } = null!;
        public string Trabajas { get; set; }
        public string LugarTrabajo { get; set; } = null!;

        public string ConConocimiento { get; set; }
        public string Instrumento { get; set; } = null!;
        public string InstrumentoCasa { get; set; }
        public string InstrumentotTwo { get; set; } = null!;
        public string EnterasteEsc { get; set; } = null!;
        public string InteresGnroMusical { get; set; }
        public string CualesMusicales { get; set; } = null!;

        public string ClaseOpcional { get; set; }
        public string DescuentoP { get; set; }
        public string Amables { get; set; }
        public string NombreRecepcionista { get; set; } = null!;

        public string StringActivo { get; set; }
    }
}
