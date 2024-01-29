using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static EMAI.Comun.Models.EventosIDModel;

namespace EMAI.LND
{
    public class EventosOperaciones : IEventosOperaciones 
    {
        //Mostrar todo
        public async Task<List<EventosModel>> GetEventos()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetEventos();
            return rsp;
        }

        //Mostrar por ID
        public async Task<EventosIDModel> GetEventosID(int IdEvento)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetEventosID(IdEvento);
            return rsp;
        }

        //Insertar un Evento
        public async Task<bool> InsertarEvento(EventoInsertarModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarEvento(value);
            return rsp;
        }

        //Actualizar Evento
        public async Task<bool> ActualizarEvento(int IdEvento, string NombreEvento, string Fecha, int IdHora, int IdAlumno, int IdClase)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarEvento(IdEvento, NombreEvento, Fecha,IdHora, IdAlumno, IdClase);
            return rsp;
        }


        //Eliminar Evento
        public async Task<bool> EliminarEvento(int IdEvento)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarEvento(IdEvento);
            return rsp;
        }

  
    }
}
