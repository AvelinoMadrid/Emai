using emai.Models;
using emai.Servicios.Commons;

namespace emai.Servicios
{
    public interface IServicioPromosiones_Api
    {
        Task<List<PromocionesModelV1>> Lista();

        Task<BaseResponseV3<PromocionesModelV1>> ListarAllPromosiones();
        Task<PromocionesModelV1> Obtener(int IdPromociones);

        Task<bool> Guardar(PromocionesModelV1 PromocionesModelV1);

        Task<bool> Editar(PromocionesModelV1 PromocionesModelV1);

        Task<bool> Eliminar(int IdPromociones);

        Task<BaseResponseV4<bool>> EliminarPromosionV1(int IdPromociones);


        Task<BaseResponseV4<bool>> InsertarPromocionV1(PromocionesModelV1 entity);


        Task<bool> RegistrarPromocion(PromocionesModelV1 PromocionesModelV1);

        //Task<List<PromocionesModelV1>> ObtenerTodos();

        //Task<BaseResponseV3<bool>> EliminarpromosionesV1(int IdPromociones);
    }
}
