using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EMAI.Comun.Models;
using EMAI.Entidades;
using EMAI.Servicios;
namespace EMAI.Servicios
{
    public interface IAlumnosOperaciones
    {
        // obtener todos los datos 
        Task<List<AlumnosModel>> GetAlumnos();
        Task<ObtenerAlumno> GetAlumnosbyID(int id);
        Task<bool> InsertarAlumno(InsertAlumnoModel value);
        Task<bool> DeleteByIdAlumno(int Id);
        Task<bool> UpdateAlumnos(int IdAlumno, string Tag, int NoDiaClases, DateTime FechaInicioClaseGratis, DateTime FechaFinClaseGratis, string Nombre, string ApellidoP, string ApellidoM,
            int Edad, DateTime FechaNacimiento, string TelefonoCasa, string Celular, string Facebook, string Email, string Enfermedades, bool Discapacidad, string InstrumentoBase, string Dia,
            string Hora, string InstrumentoOpcional, string DiaOpcional, string HoraOpcional, string CelularPapas, string EmailPapas, string RecogerPapas, string CelularTR, string NumEmergencia);

        




    }
}
