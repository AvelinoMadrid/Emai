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
    public class LibrosOperaciones: ILibrosOperaciones
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

        public async Task<bool> UpdateLibro(int IDLibro, decimal costo)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.UpdateLibro(IDLibro, costo);
            return rsp;
        }

        public async Task<bool> StatusDesactivadoLibro(int IdLibro)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.StatusDesactivadoLibro(IdLibro);
            return rsp; 
        }

        public async Task<bool> StatusActivadorLibro(int IdLibro)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.StatusActivadorLibro(IdLibro);
            return rsp;
        }

    }
}
