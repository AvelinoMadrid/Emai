using emai.Models;

namespace emai.Servicios
{
    public interface IServicioPago_Api
    {
        Task<List<Pago>> Lista();

        Task<Pago> Obtener(int IdPago);

        Task<bool> Guardar(Pago Pago);

        Task<bool> Editar(Pago Pago);

        Task<bool> Eliminar(int IdPago);
    }
}
