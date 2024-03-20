
using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IAsignacionMaestroOperaciones
    {


        Task<List<AsigMaestroModel>> GetAsigMaestro1();
        Task<AsigMaestroId> GetAsigMaestroId1(int AsgnId);

        Task<bool> AsignarMaestro(AsigMaestro1Asignar value); 


        Task<bool> EliminarAsignacionMaestro(int AsgnId);

        Task<bool> ActualizarAsigMaestro(int AsgnId,int IdMaestro,int IdClase,int IdHorario);


    }
}
