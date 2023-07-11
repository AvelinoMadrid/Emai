using emai.Models;

namespace emai.Servicios
{
    public interface IServicioNomina_Api
    {
        Task<List<Nomina>> Lista();
        Task<Nomina> Obtener(int IdNomina);
        Task<bool> Guardar(Nomina Nomina);
        Task<bool> Editar(Nomina Nomina);
        Task<bool> Eliminar(int IdNomina);

    }
}
