using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class AlumnosModel
    {
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
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

        public string Img { get; set; }
        // tabla Papàs
        public string NombrePapa { get; set; }
        public string TelefonoPapa { get; set; }
        public string FacebookPapa { get; set; }
        public string Emailpapas { get; set; }
        public string TutorRecoger { get; set; }
        public string CelularTR { get; set; }
        public string NumEmergencia { get; set; }

        // tabla estudios 
        public bool Estudios { get; set; }
        public string GradoEstudios { get; set; }
        public string EscuelaActual { get; set; }
        public bool Trabajo { get; set; }
        public string LugarTrabajo { get; set; }

        // tabla conociientos Musicales
        public string conActual { get; set; }
        public string instrumentoMusical { get; set; }
        public bool InstrumentoCasa { get; set; }
        public string NoInstrumentoMusical { get; set; }
        public string EntersteEsc { get; set; }
        public bool interesGnroMusical { get; set; }
        public string interesgros { get; set; }


        // tabla interes instrumento 
        public string interes { get; set; }


        // tabla personal 
        public bool classOpcional { get; set; }
        public bool Descuento { get; set; }
        public bool Amable { get; set; }

        // tabla repecionista 

        public int IDRecepcionista { get; set; }

        public string NombreRecepcionista { get; set; }
    }

    // buscar por id
    public class AlumnosbyIDModel
    {
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
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

        public string Img { get; set; }

        //// tabla Papà
        public int IdPapas { get; set; }
        public string NombrePapas { get; set; }
        public string TelefonoPapa { get; set; }
        public string FacebookPapa { get; set; }
        public string TutorRecoger { get; set; }
        public string CelularTR { get; set; }
        public string NumEmergencia { get; set; }
        public string EmailPapa { get; set; }

        //// tabla estudios 
        
        public int IdEstudios { get; set; }
        public bool Estudios { get; set; }
        public string GradoEstudios { get; set; }
        public string EscuelaActual { get; set; }
        public bool Trabajo { get; set; }
        public string LugarTrabajo { get; set; }

        //// tabla conociientos Musicales
        
        public int IdConocimientoMusicales { get; set; }
        public string conActual { get; set; }
        public string instrumentoMusical { get; set; }
        public string NoInstrumentoMusical { get; set; }
        public string EntersteEsc { get; set; }
        public bool interesGnroMusical { get; set; }
        public string interesgros { get; set; }
        public bool InstrumentoCasa { get; set; }
       
        //// tabla interes instrumento 
        
        public int IdInteresInstrumento { get; set; }
        public string interes { get; set; }

        public string otro { get; set; }

        //// tabla personal 
        
        public int Idpersonal { get; set; }
        public bool classOpcional { get; set; }
        public bool Descuento { get; set; }
        public bool amable { get; set; }

        //// tabla repecionista 
        public int IDRecepcionista { get; set; }
        public string NombreRecepcionista { get; set; }
    }





    // Insert model
    public class InsertAlumnoModel
    {

        // tabla Alumnos 
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
        public DateTime FechaNacimiento{get;set;}
        public string TelefonoCasa { get; set; }
        public string Celular { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Enfermedades { get; set; } 
        public bool Discapacidad { get; set; }
        public string InstrumentoBase { get; set; }
        public string Dia { get;set; }  
        public string InstrumentoOpcional { get; set; }
        public string DiaOpcio { get; set; }
        public string HoraOpcio { get; set; }

        // Tabla papas
        public string NombrePapa { get; set; }
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

    }
    
    // actualizar

    public class AlumnosUpdateModel
    {
        // Tabla Alumnos
        public int IdAlumno { get; set; }
        //public DateTime FechaInscripcion { get; set; }
        public int IdClase { get; set; }
        public string Tag { get; set; }
        public int NoDiaClases { get; set; }
        public DateTime FechaInicioClaseGratis { get; set; }
        public DateTime FechaFinClaseGratis { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set;}
        public string TelefonoCasa { get; set; }
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

        // tabla Papas 
        public string CelularPapas { get; set; }
        public string EmailPapas { get; set; }
        public string RecogerPapas { get; set; }
        public string CelularTR { get; set; }
        public string NumEmergencia { get; set; }


    }


    // EJEMPLO DE MODELO NUEVO DE ACTUALIZAR
    public class ObtenerAlumno
    {
        public int IDAlumno { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaInscripcion{get;set ;}
        public string Tag { get; set; } 
        public int NoDiaClases { get; set; }    
        public DateTime FechaInicioClaseGratis { get; set; }
        public DateTime FechaFinClaseGratis { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNaciminto { get; set; }
        public string TelCasa { get; set; } 
        public string Celular { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Enfermedades { get; set; }
        public bool Discapacidad { get; set; }
        public string Instrumentobase { get; set; } 
        public string Dia { get; set; }
        public string Hora { get; set; }    
        public string InstrumentoOpcional { get; set; }
        public string DiaOpcional { get; set; }
        public string HoraOpcional { get; set; }

        //public string IMG { get; set; }

        // Tabla Papas 

        public string NombrePapas { get; set; }
        public string CelularPapas { get; set; }
        public string FacebookPaps { get; set; }
        public string EmailPapas { get; set; }
        public string TutorRecoger { get; set; }
        public string CelularTR { get; set; }
        public string NumeroEmergencia { get; set; }


        // tabla estudios 
        public bool Estudios { get; set; }
        public string GradoEstudios { get; set; }
        public string EscuelaActual { get; set; }
        public bool Trabajas { get; set; }
        public string LugarTrabajo { get; set; }

        // TABLA CONOCIMIENTOS MUSICALES 
        public string ConActual { get; set; }
        public string Instrumento { get; set; }
        public bool InstrumentoCasa { get; set;}
        public string NoInstrumento { get; set; }
        public string EnterasteESc { get;set; }
        public bool InteresGroMusical { get; set; }
        public string Cuales { get; set; }

        // TABLA INTERES 

        public string Otro { get; set; }

        // TABLA PERSONAL 
        public bool ClasOpcional { get; set; }
        public bool Descuento { get; set; }
        public bool Amable { get; set; }

        // TABLA RECEPCIONISTA 
        public string NombreRecepcionista { get; set; }


    }








}
