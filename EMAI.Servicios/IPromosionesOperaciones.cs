using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IPromosionesOperaciones
    {
        Task<List<PromosionesModel>> GetPromosiones();
        Task<PromosionesIDModel> GetPromosionesID(int IdPromosiones);
        Task<bool> InsertarPromosiones(PromosionesInsertarModel value);
        Task<bool> ActualizarPromosiones(int IdPromosion, int IdAlumno, int Porcentaje, DateTime Fecha);
        Task<bool> EliminarPromosiones(int IdPromosiones);

    }
}
