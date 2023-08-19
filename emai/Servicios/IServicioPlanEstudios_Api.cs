using emai.Models;

namespace emai.Servicios
{
    public interface IServicioPlanEstudios_Api
    {
        Task<List<PlanEstudios>> Lista();
    }
}
