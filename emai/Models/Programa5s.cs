using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Programa5s
    {
        public int Id { get; set; }

        public string Area { get; set; }
        public string Supervisor { get; set; }

        public DateTime FechaAntes { get; set; }

        public DateTime FechaInicio { get; set; }

        public string ImagenAntes { get; set; }

        public string ImagenDespues { get; set; }

        public string Detalles { get; set; }

        public List<Programa5s> Lista { get; set; }


    }
}
