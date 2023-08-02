using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class AsigClaseModel
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }

    public class AsigClaseId
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }

    public class AsigClaseEliminar
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }

    public class AsigClaseAsignar
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
