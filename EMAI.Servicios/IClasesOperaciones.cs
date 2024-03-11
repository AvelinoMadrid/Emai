using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Base;
using EMAI.DTOS.Dtos.Response;

namespace EMAI.Servicios
{
    public interface IClasesOperaciones
    {
        //Obtener todos los datos
        Task<List<ClasesModel>> GetClases();
        Task<List<ListaClases>> GetNombreClases();
        Task<BaseResponse<List<SelectClasesUnique>>> GetSelectClasesUnique();
        Task<ClasesIdModel> GetClasesId(int IdClase);
        Task<bool> InsertarClase(ClasesModelInsertar value);
        Task<bool> ActualizarClase(int IdClase, string Nombre, string CNormal, string CVerano, string Dia, string Dia2, string Dia3, decimal Costo);
        Task<bool> EliminarClase(int IdClase);

    }
}