using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface IClasesOperaciones
    {
        //Obtener todos los datos
        Task<List<ClasesModel>> GetClases();

        Task<ClasesIdModel> GetClasesId(int IdClase);

        Task<bool> InsertarClase(ClasesModelInsertar value);

        Task<bool> ActualizarClase(int IdClase, string Nombre, string CNormal, string CVerano, string Dia, string Horario, string Dia2, string Horario2, string Dia3, string Horario3, decimal Costo, string ClaseOpc, string HorarioOpc, string DiaOpc);

        Task<bool> EliminarClase(int IdClase);

    }
}
