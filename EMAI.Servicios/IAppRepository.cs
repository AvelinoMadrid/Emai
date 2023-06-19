using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


using System.Threading.Tasks;
using EMAI.Comun.Models;



namespace EMAI.Servicios
{
    public interface IAppRepository : IDisposable
    {

        string ErrorMessageSp { get; set; }
        bool Respuesta { get; set; }

        #region "Alumnos"  

        Task<List<AlumnosModel>> GetAlumnos();

        Task<AlumnosbyIDModel> GetAlumnosbyID(int id);
        Task<bool> InsertarAlumno(InsertAlumnoModel value);

        Task<bool> DeleteByIdAlumno(int Id);

        Task<bool> UpdateAlumnos(int IdAlumno, string Tag, int NoDiaClases, DateTime FechaInicioClaseGratis, DateTime FechaFinClaseGratis, string Nombre, string ApellidoP, string ApellidoM,
           int Edad, DateTime FechaNacimiento, string TelefonoCasa, string Celular, string Facebook, string Email, string Enfermedades, bool Discapacidad, string InstrumentoBase, string Dia,
           string Hora, string InstrumentoOpcional, string DiaOpcional, string HoraOpcional, string CelularPapas, string EmailPapas, string RecogerPapas, string CelularTR, string NumEmergencia);



        #endregion

        #region "Asistencia"

        Task<List<AsistenciaModel>> GetAllAsistencias();
        Task<AsistenciaModel> GetAsistenciaByID(int id);

        Task<bool> InsertarAlumnoAsistencia(InsertAsistenciaModel value);
        Task<bool> DeleteAsistenciabyID(int id);
        Task<bool> UpdateAsistencia(int id, int IdAlumno, int IdClase, DateTime Fecha, bool Asistencia);

        #endregion

        #region "Clases"
        Task<List<ClasesModel>> GetClases();
        Task<ClasesIdModel> GetClasesId(int IdClase);
        Task<bool> InsertarClase(ClasesModelInsertar value);
        Task<bool> ActualizarClase(int IdClase, string Nombre, string CNormal, string CVerano, string Dia, string Horario, string Dia2, string Horario2, string Dia3, string Horario3, decimal Costo, string ClaseOpc, string HorarioOpc, string DiaOpc);
        Task<bool> EliminarClase(int IdClase);

        #endregion

        #region "Maestros"
        Task<List<HorariosModel>> GetHorarios();
        Task<HorariosIDModel> GetHorariosID(int IdHorario);
        Task<bool> InsertarHorario(HorariosInsertarModel value);
        Task<bool> ActualizarHorario(int IdHorario, int IdAlumno, int IdMaestro, int IdClase, string Dia, DateTime Fecha);
        Task<bool> EliminarHorario(int IdHorario);
        #endregion

        #region "Maestros" 
        Task<List<MaestrosModel>> GetMaestros();

        Task<MaestrosIDModel> GetMaestrosID(int IdMaestro);
        Task<bool> InsertarMaestro(MaestrosInsertarModel value);

        Task<bool> ActualizarMaestro(int IdMaestro, string Nombre, string ApellidoP, string ApellidoM, string Direccion, string Telefono, DateTime FechaNacimiento, int IdClase, int IdHorario, int IdAlumno, bool Status, bool Base, string Suplente, decimal Pago);

        Task<bool> EliminarMaestro(int IdMaestro);
        #endregion









    }
}
