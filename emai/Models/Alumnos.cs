using emai.Servicios.Commons;
using emai.Servicios.Dtos.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Alumnos
    {
        public DateTime FechaInscripcion { get; set; }
        public string Tag { get; set; } = null!;
        public int NoDiaClases { get; set; }
        public DateTime FechaInicioClase { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
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

        public string Folio { get; set; } = null!;
        public int IdPromosion { get; set; }
        public int IdMes { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal CostoLibro { get; set; }
        public string NombreLibro { get; set; } = null!;
        public string Atendio { get; set; } = null!;
        public decimal Costo { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public decimal Inscripcion { get; set; }
        public decimal Mensualidad { get; set; }

        public List<ClasesResponse> ListarClasesSelect { get; set; }
        public FolioGenerado GeneradorFolioV1 { get; set; }
        public BaseResponseV1<Promosiones> ListSelectPromocion { get; set; }
        public List<MesesModel> ListarMesesSelect { get; set; }

    }


}
