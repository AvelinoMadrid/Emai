using emai.Models;

namespace emai.Servicios
{
    public interface IServicioLibro_Api
    {
        Task<List<Libro>> Lista();
        Task<List<Libro>> ListaInactivo();
        Task<Libro> Obtener(int IdLibro);
        Task<Libro> ObtenerInactivo(int idInactivo, string Estado);
        Task<bool> Guardar(Libro Libro);
        Task<bool> Editar(Libro Libro);
        //Task<bool> EditarDes(Libro Libro);
        //Task<bool> EditarActivar(Libro Libro);
        Task<bool> ActivarLibro(Libro Libro);
        //Task<bool> DesactivarLibro(int IdLibro);


    }
}
