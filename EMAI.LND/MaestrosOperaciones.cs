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
    public class MaestrosOperaciones : IMaestrosOperaciones
    {
        //Mostrar todo
        public async Task<List<MaestrosModel>> GetMaestros()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetMaestros();
            return rsp;
        }

        //Mostrar por ID
        public async Task<MaestrosIDModel> GetMaestrosID(int IdMaestro)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetMaestrosID(IdMaestro);
            return rsp;
        }

        //Insertar un Maestro
        public async Task<bool> InsertarMaestro(MaestrosInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarMaestro(value);
            return rsp;
        }

        //Actualizar Clase

        public async Task<bool> ActualizarMaestro(int IdMaestro, string Nombre, string ApellidoP, string ApellidoM, string Direccion, string Telefono, DateTime FechaNacimiento, int IdClase, int IdHorario, int IdAlumno, bool Status, bool Base, string Suplente, decimal Pago)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarMaestro(IdMaestro,Nombre,ApellidoP,ApellidoM,Direccion,Telefono,FechaNacimiento,IdClase,IdHorario,IdAlumno,Status,Base,Suplente,Pago);
            return rsp;
        }

        //Eliminar maestro
        public async Task<bool> EliminarMaestro(int IdMaestro)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarMaestro(IdMaestro);
            return rsp;
        }
    }
}
