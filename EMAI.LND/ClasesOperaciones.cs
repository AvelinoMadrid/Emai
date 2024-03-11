using EMAI.Comun.Models;
using EMAI.Datos;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Response;
using EMAI.Servicios;
using Email.Utiilities.Static;
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

        // Mostrar clase nombre
        public async Task<List<ListaClases>> GetNombreClases()
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.GetNombreClases();
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

        public async Task<bool> ActualizarClase(int IdClase, string Nombre, string CNormal, string CVerano, string Dia, string Dia2, string Dia3, decimal Costo)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.ActualizarClase(IdClase, Nombre, CNormal, CVerano, Dia, Dia2, Dia3, Costo);
            return rsp;
        }

        //ELIMINAR
        public async Task<bool> EliminarClase(int IdClase)
        {
            using var db = AppRepositoryFactory.GetAppRepository();
            var rsp = await db.EliminarClase(IdClase);
            return rsp;
        }

        public async Task<BaseResponse<List<SelectClasesUnique>>> GetSelectClasesUnique()
        {
            var response = new BaseResponse<List<SelectClasesUnique>>();
            try
            { 
                using var db = AppRepositoryFactory.GetAppRepository();

                var listClase = await db.GetListaUniqueHorario();

                if (listClase != null)
                {
                    response.IsSuccess = true;
                    response.Data = listClase;
                    response.Message = StaticVariable.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = StaticVariable.MESSAGE_FALLED;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
