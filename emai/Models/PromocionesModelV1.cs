using emai.Servicios.Commons;


namespace emai.Models
{
    public class PromocionesModelV1
    {
        public int IdPromociones { get; set; }
        public string NombrePromocion { get; set; }
        public string Porcentaje { get; set; }
        public string statePromocion { get; set; }

        public BaseResponseV3<PromocionesModelV1> ListarAllPromosiones { get; set; }
    }
}
 