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
    public class ClasesOperaciones : IClasesOperaciones
    {
        //MOSTRAR
        public async Task<List<ClasesModel>> GetClases()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetClases();
            return rsp;
        }
        //Buscar por Id
        public async Task<ClasesIdModel> GetClasesId(int IdClase)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetClasesId(IdClase);
            return rsp;
        }

        //Insertar clase

        public async Task<bool> InsertarClase(ClasesModelInsertar value)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.InsertarClase(value);
            return rsp;
        }

        //Actualizar Clase

        public async Task<bool> ActualizarClase(int IdClase, string Nombre, string CNormal, string CVerano, string Dia, string Horario, string Dia2, string Horario2, string Dia3, string Horario3, decimal Costo, string ClaseOpc, string HorarioOpc, string DiaOpc)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarClase(IdClase, Nombre, CNormal, CVerano, Dia, Horario, Dia2, Horario2, Dia3, Horario3, Costo, ClaseOpc, HorarioOpc, DiaOpc);
            return rsp;
        }

        //ELIMINAR
        public async Task<bool> EliminarClase(int IdClase)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarClase(IdClase);
            return rsp;
        }






    }
}
