using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static EMAI.Comun.Models.RepClaseModel;

namespace EMAI.Servicios
{
    public interface IRepClaseOperaciones
    {
        Task<List<RepClaseModel>> GetRepClase();
        Task<RepClaseIDModel> GetRepClaseID(int IdRepClase);
        Task<bool> InsertarRepClase(RepClaseInsertarModel value);
        Task<bool> ActualizarRepClase(int IdRepClase, int IdClase, int IdMaestro, int IdAlumno, string DiaRep);
        Task<bool> EliminarRepClase(int IdRepClase);
    }
}
