using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class AsigClase
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }

        public string NombreMaestro { get; set; }
        public string NombreClase { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public int IdClaseOpc { get; set; }

        public List<AsigClase> Lista { get; set; }

        public List<Maestro> MaestrosDisponibles { get; set; }
        public List<Clase> ClasesDisponibles { get; set; }
    }
}
