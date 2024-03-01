using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Alumnos
    {
        public int IdAlumno { get; set; }

        public int IdClase { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Tag { get; set; }
        public int NoDiaClases { get; set; }
        public DateTime FechaInicioClaseGratis { get; set; }
        public DateTime FechaFinClaseGratis { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string telefono { get; set; }
        public string Celular { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Enfermedades { get; set; }
        public bool Discapacidad { get; set; }
        public string InstrumentoBase { get; set; }
        public string Dia { get; set; }
        public string InstrumentoOpcional { get; set; }
        public string diaOpcional { get; set; }
        public string horaOpcional { get; set; }

        // Tabla papas
        public string NombrePapas { get; set; }
        public string CelularPapas { get; set; }
        
        public string FacebookPapas { get; set; }
        public string EmailPapas { get; set; }
        public string TutorRecoger { get; set; }
        public string CelularTR { get; set; }
        public string NumEmergencia { get; set; }

        //tabla estudios 
        public bool Estudios { get; set; }
        public string GradoEstudios { get; set; }
        public string EscuelaActuales { get; set; }
        public bool Trabajas { get; set; }
        public string LugarTrabajo { get; set; }


        // Tabla conocimientos Actuales
        public string ConActual { get; set; }
        public string Instrumento { get; set; }
        public bool InstrumentoCasa { get; set; }
        public string NoInstrumento { get; set; }
        public string EnterasteEscuela { get; set; }
        public bool InteresGnroMusical { get; set; }
        public string Cuales { get; set; }

        // Tabla interes Instrumento
        public string Otro { get; set; }

        // Tabla Personal 
        public bool ClaseOpcional { get; set; }
        public bool DescuentoP { get; set; }
        public bool amable { get; set; }

        // Tabla Recepcionista 


        //public int IdRecepcionista { get; set; }
        public string NombreRecepcionista { get; set; }

        public List<Alumnos> Lista { get; set; }
       

    }


}
