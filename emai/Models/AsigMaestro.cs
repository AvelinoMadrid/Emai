using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace emai.Models
{
    public class AsigMaestro
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get;  set; }

        public string NombreMaestro { get; set; }
        public string NombreClase { get;  set; }
        public string Horario { get; set; }

        public DateTime Fecha { get; set; }

        public List<AsigMaestro> Lista { get; set; }

        public List<Maestro> MaestrosDisponibles { get; set; }
        public List<Clase> ClasesDisponibles { get; set; }
        public List<Horario> HorariosDisponibles { get; set; }
    }
}
