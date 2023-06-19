using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class AsistenciaOperaciones: IAsistenciaOperaciones
    {


        //MOSTRAR
        public async Task<List<AsistenciaModel>> GetAllAsistencias()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAllAsistencias();
            return rsp;
        }

        public async Task<AsistenciaModel> GetAsistenciaByID(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAsistenciaByID(id);
            return rsp;
        }

        public async Task<bool> InsertarAlumnoAsistencia(InsertAsistenciaModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarAlumnoAsistencia(value);
            return rsp;
        }

        public async Task <bool> DeleteAsistenciabyID(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.DeleteAsistenciabyID(id);
            return rsp;
        }

        public async Task<bool> UpdateAsistencia(int id, int IdAlumno, int IdClase, DateTime Fecha, bool Asistencia)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.UpdateAsistencia(id,IdAlumno,IdClase,Fecha,Asistencia);
            return rsp;
        }




    }
}
