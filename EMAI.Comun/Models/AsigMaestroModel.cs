using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class AsigMaestroModel
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
    }

    public class AsigMaestroId
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
    }

    public class AsigMaestroEliminar
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
    }

    public class AsigMaestro1Asignar
    {
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
    }

    public class ActualizarAsigMaestro
    {
        public int AsgnId { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public int IdHorario { get; set; }
    }
}
