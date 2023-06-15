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

        public async Task <AlumnosbyIDModel> GetAlumnosbyID(int id) 
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetAlumnosbyID(id);
            return rsp;
        
        }

     












    }
}
