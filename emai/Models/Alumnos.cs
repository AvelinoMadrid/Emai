using emai.Servicios.Commons;
using emai.Servicios.Dtos.Response;
using System.ComponentModel.DataAnnotations;
namespace emai.Models
{
    public class Alumnos
    {
        public int IdAlumno { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FechaInscripcion { get; set; }
        public string Tag { get; set; } = null!;
        public int NoDiaClases { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FechaInicioClase { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int Edad { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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

        public bool ConConocimiento { get; set; }//
        public string Instrumento { get; set; } = null!;
        public bool InstrumentoCasa { get; set; }//
        public string InstrumentotTwo { get; set; } = null!;
        public string EnterasteEsc { get; set; } = null!;
        public bool InteresGnroMusical { get; set; }//
        public string CualesMusicales { get; set; } = null!;

        public string TipoInteres { get; set; } = null!;
        public string OtroOpcional { get; set; } = null!;
        public string MusicalInteres { get; set; } = null!;
        public bool ClaseOpcional { get; set; }//
        public bool DescuentoP { get; set; }//
        public bool Amables { get; set; }
        public string NombreRecepcionista { get; set; } = null!;

        public string Folio { get; set; } = null!;
        public int IdPromosion { get; set; }
        public int IdMes { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FechaPago { get; set; }
        public decimal CostoLibro { get; set; }
        public string NombreLibro { get; set; } = null!;
        public string Atendio { get; set; } = null!;
        public decimal Total { get; set; }
        public decimal Inscripcion { get; set; }
        public decimal Mensualidad { get; set; }
        public void asingarResponseV1(AlumnoResponseById data)
        {
            this.IdAlumno = data.IdAlumno;
            this.FechaInscripcion = data.FechaInscripcion;
            this.Tag = data.Tag;
            this.NoDiaClases = data.NoDiaClases;
            this.FechaInicioClase = data.FechaInicioClase;
            this.NombreCompleto = data.NombreCompleto;
            this.Edad = data.Edad;
            this.FechaNacimiento = data.FechaNacimiento;
            this.TelefonoCasa = data.TelefonoCasa;
            this.Celular = data.Celular;
            this.Facebook = data.Facebook;
            this.Email = data.Email;
            this.Enfermedades = data.Enfermedades;
            this.SeleccionarClase1 = data.SeleccionarClase1;
            this.DiaAndHoraClase = data.DiaAndHoraClase;
            this.SeleccionarClase2 = data.SeleccionarClase2;
            this.DiaAndHoraClaseOpcional = data.DiaAndHoraClaseOpcional;
            this.Activo = ConvetirCadenaABool(data.StringActivo);
            this.NombrePapas = data.NombrePapas;
            this.CelularPapas = data.CelularPapas;
            this.EmailPapas = data.EmailPapas;
            this.TutorRecoger = data.TutorRecoger;
            this.CelularTR = data.CelularTR;
            this.NumEmergencia = data.NumEmergencia;
            this.Estudios = ConvetirCadenaABool(data.Estudios);
            this.EscuelaActuales = data.EscuelaActuales;
            this.Trabajas = ConvetirCadenaABool(data.Trabajas);
            this.LugarTrabajo = data.LugarTrabajo;
            this.ConConocimiento = ConvetirCadenaABool(data.ConConocimiento);
            this.Instrumento = data.Instrumento;
            this.InstrumentoCasa = ConvetirCadenaABool(data.InstrumentoCasa);
            InstrumentotTwo = data.InstrumentotTwo;
            EnterasteEsc = data.EnterasteEsc;
            InteresGnroMusical = ConvetirCadenaABool(data.InteresGnroMusical);
            CualesMusicales = data.CualesMusicales;
            ClaseOpcional = ConvetirCadenaABool(data.ClaseOpcional);
            DescuentoP = ConvetirCadenaABool(data.DescuentoP);
            Amables = ConvetirCadenaABool(data.Amables);
            NombreRecepcionista = data.NombreRecepcionista;
        }

        private bool ConvetirCadenaABool(string valor)
        {
            var valorString = valor!.ToLower();
            if (valorString == "si" || valorString == "activo")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<ClasesResponse> ListarClasesSelect { get; set; }
        public BaseResponseV1<Promosiones> ListSelectPromocion { get; set; }
        public BaseResponseV1<ClasesResponse> ListClasesUnique { get; set; }
        public List<MesesModel> ListarMesesSelect { get; set; }
        public List<HorarioResponse> ListarHorarioSelect { get; set; }
        public string GeneradorFolioV1 { get; set; }

        public List<Alumnos> Data { get; set; }
        //public BaseResponseV1<SelectLisHorario> SelectListHorario { get; set; }
    }
}
