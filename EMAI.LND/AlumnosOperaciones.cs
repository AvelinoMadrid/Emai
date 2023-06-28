using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class AlumnosOperaciones : IAlumnosOperaciones
    {

        //MOSTRAR
        public async Task<List<AlumnosModel>> GetAlumnos()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAlumnos();
            return rsp;
        }

        public async Task<ObtenerAlumno> GetAlumnosbyID(int id) 
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAlumnosbyID(id);
            return rsp;
        
        }

        public async Task<bool> InsertarAlumno(InsertAlumnoModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarAlumno(value);
            return rsp;
        }

        //ELIMINAR
        public async Task<bool> DeleteByIdAlumno(int Id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.DeleteByIdAlumno(Id);
            return rsp;
        }

        // ACTUALIZAR ALUMNO 
        public async Task<bool> UpdateAlumnos(int IdAlumno, string Tag, int NoDiaClases, DateTime FechaInicioClaseGratis, DateTime FechaFinClaseGratis, string Nombre, string ApellidoP, string ApellidoM,int Edad, DateTime FechaNacimiento, string TelefonoCasa, string Celular, string Facebook, string Email, string Enfermedades, bool Discapacidad, string InstrumentoBase, string Dia,string Hora, string InstrumentoOpcional, string DiaOpcional, string HoraOpcional, string CelularPapas, string EmailPapas, string RecogerPapas, string CelularTR, string NumEmergencia)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.UpdateAlumnos(IdAlumno, Tag, NoDiaClases, FechaInicioClaseGratis,FechaFinClaseGratis, Nombre,  ApellidoP,  ApellidoM,  Edad,  FechaNacimiento,  TelefonoCasa, Celular,  Facebook,  Email,  Enfermedades,  Discapacidad,  InstrumentoBase,  Dia,  Hora,  InstrumentoOpcional,  DiaOpcional,  HoraOpcional, CelularPapas,  EmailPapas, RecogerPapas, CelularTR, NumEmergencia);
            return rsp;
        }





    }
}
