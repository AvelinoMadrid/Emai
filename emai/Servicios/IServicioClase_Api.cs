using emai.Models;

namespace emai.Servicios
{
    public interface IServicioClase_Api
    {
        Task<List<Clase>> Lista();

        Task<Clase> Obtener(int IdClase);

        Task<bool> Guardar(Clase clase);

        Task<bool> Editar(Clase clase);

        Task<bool> Eliminar(int IdClase);
    }

}
