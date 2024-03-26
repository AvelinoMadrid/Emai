using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.DTOS.Dtos.Request
{
    public class AlumnoRequestV1
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string FechaInscripcion { get; set; }
        public string Tag { get; set; } = null!;
        public int NoDiaClases { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string FechaInicioClase { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int Edad { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
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
        public bool Activo { get; set; }

        public string NombrePapas { get; set; } = null!;
        public string CelularPapas { get; set; } = null!;
        public string FacebookPapas { get; set; } = null!;
        public string EmailPapas { get; set; } = null!;
        public string TutorRecoger { get; set; } = null!;
        public string CelularTR { get; set; } = null!;
        public string NumEmergencia { get; set; } = null!;

        public bool Estudios { get; set; }
        public string GradoEstudios { get; set; } = null!;
        public string EscuelaActuales { get; set; } = null!;
        public bool Trabajas { get; set; }
        public string LugarTrabajo { get; set; } = null!;

        public bool ConConocimiento { get; set; }
        public string Instrumento { get; set; } = null!;
        public bool InstrumentoCasa { get; set; }
        public string InstrumentotTwo { get; set; } = null!;
        public string EnterasteEsc { get; set; } = null!;
        public bool InteresGnroMusical { get; set; }
        public string CualesMusicales { get; set; } = null!;

        public string TipoInteres { get; set; } = null!;
        public string OtroOpcional { get; set; } = null!;
        public string MusicalInteres { get; set; } = null!;
        public bool ClaseOpcional { get; set; }
        public bool DescuentoP { get; set; }
        public bool Amables { get; set; }
        public string NombreRecepcionista { get; set; } = null!;
    }
}
