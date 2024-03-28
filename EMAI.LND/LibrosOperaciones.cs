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
    public class LibrosOperaciones : ILibrosOperaciones
    {

        public async Task<List<LibrosModel>> GetAllLibros()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAllLibros();
            return rsp;

        }

        public async Task<LibrosModel> GetLibrobyId(int id)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetLibrobyId(id);
            return rsp;
        }

        public async Task<bool> InsertLibro(InsertLibrosModel value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertLibro(value);
            return rsp;

        }

        public async Task<bool> UpdateLibro(int IdLibro, string NombreLibro, string DescripcionLibro, decimal Costo, string Estado)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.UpdateLibro(IdLibro, NombreLibro, DescripcionLibro, Costo, Estado);
            return rsp;
        }


        public async Task<bool> ActivarLibro(int IdLibro, string Estado)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActivarLibro(IdLibro, Estado);
            return rsp;
        }

        /*public async Task<bool> DesactivarLibro(int IdLibro)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.DesactivarLibro(IdLibro);
            return rsp;
        }
        */

        /*LIBROA INACTIVOS */
        public async Task<List<LibrosModel>> GetAllLibrosInactivos()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAllLibrosInactivo();
            return rsp;
        }

        public async Task<LibrosModel> GetLibrobyIdInactivos(int idInactivo)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetLibrobyIdInactivos(idInactivo);
            return rsp;
        }
    }
}
