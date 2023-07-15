using emai.Models;

namespace emai.Servicios
{
    public interface IServicioLibro_Api
    {
        Task<List<Libro>> Lista();
        Task<Libro> Obtener(int IdLibro);
        Task<bool> Guardar(Libro Libro);
        Task<bool> Editar(Libro Libro);
        Task<bool> EditarDes(Libro Libro);
        Task<bool> EditarActivar(Libro Libro);
    }
}
