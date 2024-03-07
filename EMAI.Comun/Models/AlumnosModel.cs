using System;
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
    public class AlumnosModel
    {
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaInscripcion { get; set; } //1
        public string Tag { get; set; }    //2
        public int NoClasesDia { get; set; } // 3
        public DateTime FechaInicioClaseGratis { get; set; } //4
        /*public DateTime FechaFinClaseGratis { get; set; }*/  // sufren modificaciones de acuerdo a nuevos requirimientos 
        public string Nombre { get; set; } //8
        /*public string ApPaterno { get; set; }*/ // sufren modificaciones de acuerdo a nuevos requirimientos
        /*public string ApMaterno { get; set; }*/ // sufren modificaciones de acuerdo a nuevos requirimientos
        public int Edad { get; set; } //9
        public DateTime FechaNacimiento { get; set; } //10
        public string Telefono { get; set; } //11
        public string Celular { get; set; } //12
        public string Facebook { get; set; } //13
        public string Email { get; set; } //14
        public string Enfermedades { get; set; } // 15

        //public bool Discapacidad { get; set; } // sufren modificaciones de acuerdo a nuevos requirimientos  
        public string InstrumentoBase { get; set; } //5
        public string Diayhora { get; set; }  // 6.-se va a trasladar como DiayHora
        //public string Hora { get; set; } // sufren modificaciones de acuerdo a nuevos requirimientos 
        public string InstrumentoOpcional { get; set; } //7
        public string DiaOpcional { get; set; } // => se va a trasladar como DiayhoraOpcional
        /* public string HoraOpcional { get; set; }*/ // sufren modificaciones de acuerdo a nuevos requirimientos 

        public string Img { get; set; }


        // tabla Papàs
        public string NombrePapa { get; set; } // 16
        public string TelefonoPapa { get; set; } //17
        public string FacebookPapa { get; set; } // 18
        public string Emailpapas { get; set; } // 19
        public string TutorRecoger { get; set; } // 20
        public string CelularTR { get; set; } // 21
        public string NumEmergencia { get; set; } // 22



        // tabla estudios 
        public bool Estudios { get; set; } // 23
        public string GradoEstudios { get; set; } // 24
        public string EscuelaActual { get; set; } // 25
        public bool Trabajo { get; set; } // 26
        public string LugarTrabajo { get; set; } // 27

        // tabla conociientos Musicales
        public string conActual { get; set; } // 28
        public string instrumentoMusical { get; set; } // 29
        public bool InstrumentoCasa { get; set; } // 30
        public string NoInstrumentoMusical { get; set; } // 31
        public string EntersteEsc { get; set; } // 32
        public bool interesGnroMusical { get; set; } // 33
        public string interesgros { get; set; } // 34


        // tabla interes instrumento 
        public string interes { get; set; } // 35


        // tabla personal 
        public bool classOpcional { get; set; } // 36
        public bool Descuento { get; set; } // 37
        public bool Amable { get; set; } // 38

        // tabla repecionista 

        public int IDRecepcionista { get; set; } // 38

        public string NombreRecepcionista { get; set; } // 39
    }

    // buscar por id
    public class AlumnosbyIDModel
    {
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaInscripcion { get; set; } //1
        public string Tag { get; set; }    //2
        public int NoClasesDia { get; set; } // 3
        public DateTime FechaInicioClaseGratis { get; set; } //4
        /*public DateTime FechaFinClaseGratis { get; set; }*/  // sufren modificaciones de acuerdo a nuevos requirimientos 
        public string Nombre { get; set; } //8
        /*public string ApPaterno { get; set; }*/ // sufren modificaciones de acuerdo a nuevos requirimientos
        /*public string ApMaterno { get; set; }*/ // sufren modificaciones de acuerdo a nuevos requirimientos
        public int Edad { get; set; } //9
        public DateTime FechaNacimiento { get; set; } //10
        public string Telefono { get; set; } //11
        public string Celular { get; set; } //12
        public string Facebook { get; set; } //13
        public string Email { get; set; } //14
        public string Enfermedades { get; set; } // 15

        //public bool Discapacidad { get; set; } // sufren modificaciones de acuerdo a nuevos requirimientos  
        public string InstrumentoBase { get; set; } //5
        public string Diayhora { get; set; }  // 6.-se va a trasladar como DiayHora
        //public string Hora { get; set; } // sufren modificaciones de acuerdo a nuevos requirimientos 
        public string InstrumentoOpcional { get; set; } //7
        public string DiaOpcional { get; set; } // => se va a trasladar como DiayhoraOpcional
        /* public string HoraOpcional { get; set; }*/ // sufren modificaciones de acuerdo a nuevos requirimientos 

        public string Img { get; set; }


        // tabla Papàs
        public int IdPapas { get; set; }

        public string NombrePapas { get; set; } // 16
        public string TelefonoPapa { get; set; } //17
        public string FacebookPapa { get; set; } // 18
        public string EmailPapa { get; set; } // 19
        public string TutorRecoger { get; set; } // 20
        public string CelularTR { get; set; } // 21
        public string NumEmergencia { get; set; } // 22

        // tabla estudios 
        public int IdEstudios { get; set; }
        public bool Estudios { get; set; } // 23
        public string GradoEstudios { get; set; } // 24
        public string EscuelaActual { get; set; } // 25
        public bool Trabajo { get; set; } // 26
        public string LugarTrabajo { get; set; } // 27

        // tabla conociientos Musicales
        public int IdConocimientoMusicales { get; set; }
        public string conActual { get; set; } // 28
        public string instrumentoMusical { get; set; } // 29
        public bool InstrumentoCasa { get; set; } // 30
        public string NoInstrumentoMusical { get; set; } // 31
        public string EntersteEsc { get; set; } // 32
        public bool interesGnroMusical { get; set; } // 33
        public string interesgros { get; set; } // 34


        // tabla interes instrumento 
        public int IdInteresInstrumento { get; set; }
        public string interes { get; set; } // 35

        public string otro { get; set; }

        // tabla personal 
        public int Idpersonal { get; set; }
        public bool classOpcional { get; set; } // 36
        public bool Descuento { get; set; } // 37
        public bool amable { get; set; } // 38

        // tabla repecionista 

        public int IDRecepcionista { get; set; } // 38

        public string NombreRecepcionista { get; set; } // 39
    }

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



    // Insert model
    public class InsertAlumnoModel
    {
        // tabla Alumnos 
        public int IdClase { get; set; }
        public DateTime FechaInscripcion { get; set; } // 1
        public string Tag { get; set; } // 2
        public int NoDiaClases { get; set; } // 3
        public DateTime FechaInicioClaseGratis { get; set; } //4

        public string Nombre { get; set; } // 8
        //public string ApPaterno { get; set; }
        //public string ApMaterno { get; set; }
        public int Edad { get; set; } //9
        public DateTime FechaNacimiento { get; set; } //9
        public string TelefonoCasa { get; set; } // 10
        public string Celular { get; set; } // 11
        public string Facebook { get; set; } // 12
        public string Email { get; set; } // 13
        public string Enfermedades { get; set; } // 14 
        //public bool Discapacidad { get; set; }
        public string InstrumentoBase { get; set; } //5
        public string Dia { get; set; }  // 6
        public string InstrumentoOpcional { get; set; } // 7
        public string DiaOpcio { get; set; }
        //public string HoraOpcio { get; set; }

        // Tabla papas
        public string NombrePapa { get; set; } // 15
        public string CelularPapas { get; set; } //16
        public string FacebookPapas { get; set; } // 17
        public string EmailPapas { get; set; } // 18
        public string TutorRecoger { get; set; } // 19
        public string CelularTR { get; set; } // 20
        public string NumEmergencia { get; set; } // 21

        //tabla estudios 
        public bool Estudios { get; set; } // 22
        public string GradoEstudios { get; set; } // 23
        public string EscuelaActuales { get; set; } //24
        public bool Trabajas { get; set; } // 25
        public string LugarTrabajo { get; set; } // 26


        // Tabla conocimientos Actuales
        public string ConActual { get; set; } // 27
        public string Instrumento { get; set; } //28 
        public bool InstrumentoCasa { get; set; } // 29
        public string NoInstrumento { get; set; } // 30
        public string EnterasteEscuela { get; set; } // 31
        public bool InteresGnroMusical { get; set; } // 32
        public string Cuales { get; set; } // 33

        // Tabla interes Instrumento
        public string Otro { get; set; } //34

        // Tabla Personal 
        public bool ClaseOpcional { get; set; } //35
        public bool DescuentoP { get; set; } //36
        public bool amable { get; set; } // 37

        // Tabla Recepcionista 


        //public int IdRecepcionista { get; set; }
        public string NombreRecepcionista { get; set; } // 38

        // Tabla pagos

        public string Folio { get; set; } //39
        public DateTime FechaPago { get; set; } // 39
        public int IdPromosionales { get; set; } //40
        public string Mes { get; set; } //41
        public int IdClasePago { get; set; } // 42
        public int IdHorario { get; set; } //43
        public string DiaAlumnoPago { get; set; } // 44
        public string InstrumentoAlimnoPago { get; set; } //45
        public float CostoLibro { get; set; } //46
        public string NombreLibro { get; set; } //47
        public string Atendio { get; set; } //48
        public float Costo { get; set; } //49
        public float Subtotal { get; set; } //50
        public float IVA { get; set; } //51
        public float Total { get; set; } // 52


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
        public DateTime FechaNacimiento { get; set; }
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
        public DateTime FechaInscripcion { get; set; }
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
        public bool InstrumentoCasa { get; set; }
        public string NoInstrumento { get; set; }
        public string EnterasteESc { get; set; }
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

    // Nuevos Modelos para nuevos requirimientos 
    public class AlumnosNuevo
    {

        public DateTime FechaInsctipcion { get; set; }
        public string Tag { get; set; }
        public int Dias { get; set; }
        public DateTime FechaInicioClaseGratis { get; set; }
        public DateTime FechaFinClaseGratis { get; set; }
        public string InstrumentoBase { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public string InstrumentoOpcional { get; set; }
        public string HoraOpcional { get; set; }
        public string DiaOpcional { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimientoAlumno { get; set; }
        public string TelefonoCasa { get; set; }
        public string Celular { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Enfermedades { get; set; }
    }

    public class PapasNuevo
    {
        public string NombrePapa { get; set; }
        public string CelularPapa { get; set; }
        public string FacebookPapas { get; set; }
        public string Email { get; set; }
        public string NombreTutorRecoger { get; set; }
        public string CelularTutorRecoger { get; set; }
        public string NumeroEmergencia { get; set; }
    }

    public class EstudiosNuevo
    {
        public bool Estudios { get; set; }
        public string GradoEstuidos { get; set; }
        public string NombreEscuelaActual { get; set; }
        public bool trabajas { get; set; }
        public string LugarTrabajo { get; set; }
    }

    public class ConocimientosMusicales
    {
        public bool ConMusical { get; set; }
        public string InstrumentoMusicalConocimiento { get; set; }
        public bool IntrumentoCasa { get; set; }
        public string NombreInstrumentoCasa { get; set; }
        public string EnterasteEsc { get; set; }
        public bool GeneroMusical { get; set; }

        public string Cuales { get; set; }
    }

    public class Hoobys
    {
        public string Hooby { get; set; }
        public string Otro { get; set; }
        public bool ClaseOpcional { get; set; }
        public bool DescuentoP { get; set; }
        public bool Amable { get; set; }
        public string NombreRecepcionista { get; set; }
    }




}
