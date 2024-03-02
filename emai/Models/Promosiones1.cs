using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Promosiones
    {
        public int IdPromociones { get; set; }
        public string NombrePromocion { get; set; }
        public string Porcentaje { get; set; }
        public string Activo { get; set; }

        public List<Promosiones> Lista { get; set; }
    }
}
