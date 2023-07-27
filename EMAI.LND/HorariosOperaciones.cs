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
    public class HorariosOperaciones : IHorariosOperaciones
    {
        //Mostrar todo
        public async Task<List<HorariosModel>> GetHorarios()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetHorarios();
            return rsp;
        }

        //Buscar por ID
        public async Task<HorariosIDModel> GetHorariosID(int IdHorario)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetHorariosID(IdHorario);
            return rsp;
        }


        //Insertar un Horario
        public async Task<bool> InsertarHorario(HorariosInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarHorario(value);
            return rsp;
        }

        //Actualizar Horario

        public async Task<bool> ActualizarHorario(int IdHorario, int IdMaestro, int IdClase, string Dia, DateTime Fecha, DateTime HoraInicio, DateTime HoraFin)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarHorario(IdHorario,IdMaestro,IdClase,Dia,Fecha,HoraInicio,HoraFin);
            return rsp;
        }

        //Eliminar Horario
        public async Task<bool> EliminarHorario(int IdHorario)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarHorario(IdHorario);
            return rsp;
        }
    }
}
