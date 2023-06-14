using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class AlumnosModel
    {
        public int IdAlumno { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Tag { get; set; }
        public int NoClasesDia { get; set; }
        public DateTime FechaInicioClaseGratis { get; set; }
        public DateTime FechaFinClaseGratis { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Enfermedades { get; set; }
        public bool Discapacidad { get; set; }
        public string InstrumentoBase { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public string InstrumentoOpcional { get; set; }
        public string DiaOpcional { get; set; }
        public string HoraOpcional { get; set; }

        //public string Img { get; set; }
        //// tabla Papàs
        //public string NombrePapa { get; set; }
        //public string TelefonoPapa { get; set; }
        //public string FacebookPapa { get; set; }
        //public string TutorRecoger { get; set; }
        //public string CelularTR { get; set; }
        //public string NumEmergencia { get; set; }

        //// tabla estudios 
        //public bool Estudios { get; set; }
        //public string GradoEstudios { get; set; }
        //public string EscuelaActual { get; set; }
        //public bool Trabajo { get; set; }
        //public string LugarTrabajo { get; set; }

        //// tabla conociientos Musicales
        //public string conActual { get; set; }
        //public string instrumentoMusical { get; set; }
        //public string NoInstrumentoMusical { get; set; }
        //public string EntersteEsc { get; set; }
        //public bool interesGnroMusical { get; set; }
        //public string interesgros { get; set; }


        //// tabla interes instrumento 
        //public string interes { get; set; }


        //// tabla personal 
        //public bool classOpcional { get; set; }
        //public bool Descuento { get; set; }

        //// tabla repecionista 

        //public int IDRecepcionista { get; set; }
        //public string NombreRecepcionista { get; set; }
    }

    // buscar por id
    public class AlumnosbyIDModel
    {
        public int IdAlumno { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Tag { get; set; }
        public int NoClasesDia { get; set; }
        public DateTime FechaInicioClaseGratis { get; set; }
        public DateTime FechaFinClaseGratis { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }   
        public string Celular { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Enfermedades { get; set; }
        public bool Discapacidad { get; set; }
        public string InstrumentoBase { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public string InstrumentoOpcional { get; set; }
        public string DiaOpcional { get; set; }
        public string HoraOpcional { get; set; }

        //public string Img { get; set; }

        //// tabla Papàs

        public string NombrePapa { get; set; }
        public string TelefonoPapa { get; set; }
        public string FacebookPapa { get; set; }
        public string TutorRecoger { get; set; }
        public string CelularTR { get; set; }
        public string NumEmergencia { get; set; }
        public string EmailPapa { get; set; }

        //// tabla estudios 
        public bool Estudios { get; set; }
        public string GradoEstudios { get; set; }
        public string EscuelaActual { get; set; }
        public bool Trabajo { get; set; }
        public string LugarTrabajo { get; set; }

        //// tabla conociientos Musicales
        public string conActual { get; set; }
        public string instrumentoMusical { get; set; }
        public string NoInstrumentoMusical { get; set; }
        public string EntersteEsc { get; set; }
        public bool interesGnroMusical { get; set; }
        public string interesgros { get; set; }
        public bool InstrumentoCasa { get; set; }
       
        //// tabla interes instrumento 
        public string interes { get; set; }


        //// tabla personal 
        public bool classOpcional { get; set; }
        public bool Descuento { get; set; }
        public bool amable { get; set; }

        //// tabla repecionista 
        public int IDRecepcionista { get; set; }
        public string NombreRecepcionista { get; set; }
    }

}
