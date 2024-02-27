using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{

    public class PromocionesModelV1//miguel
    {
        public int IdPromociones { get; set; }
        public string NombrePromocion { get; set; } = null!;
        public decimal Porcentaje { get; set; }
        public bool Activo { get; set; }
    }


}
