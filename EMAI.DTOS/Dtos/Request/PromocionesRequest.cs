    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace EMAI.DTOS.Dtos.Request
    {
        public class PromocionesRequest
        {
            public string NombrePromocion { get; set; } = null!;
            public Decimal Porcentaje { get; set; }
            public bool Activo { get; set; }
        }   
    }
