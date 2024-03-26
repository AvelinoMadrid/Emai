﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class InsertarAlumnoModelV1 //Este Inserte Model Equivale a todo mi tabla Principal Me euivoque
    {
        public int IdAlumno { get; set; }

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

        public string Folio { get; set; } = null!;
        public int IdPromosion { get; set; }
        public int IdMes { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string FechaPago { get; set; }
        public decimal CostoLibro { get; set; }
        public string NombreLibro { get; set; } = null!;
        public string Atendio { get; set; } = null!;
        //public decimal Costo { get; set; }
        //public decimal Subtotal { get; set; } 
        //public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public decimal Inscripcion { get; set; }
        public decimal Mensualidad { get; set; }
    }


    public class InsertarAlumnoModelTwo
    {
        public int IdClase { get; set; }
        public DateTime FechaInscripcion { get; set; } // 1
        public string Tag { get; set; } // 2
        public int NoDiaClases { get; set; } // 3
        public DateTime FechaInicioClaseGratis { get; set; } //4
        public string Nombre { get; set; } // 8
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
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
