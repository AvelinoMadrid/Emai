using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class LibrosModel
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string DescripcionLibro { get; set; }
        public decimal Costo { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }

    public class LibrosModelInactivo
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string DescripcionLibro { get; set; }
        public string Estado { get; set; }
    }


    public class InsertLibrosModel
    {
        public string NombreLibro { get; set; }
        public string DescripcionLibro { get; set; }
        public decimal Costo { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }

    public class OptenerTodosLibroModel
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string DescripcionLibro { get; set; }
        public decimal Costo { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }

    public class OptenerPorIDModel
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string DescripcionLibro { get; set; }
        public decimal Costo { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }



    public class LibrosActualizarModel
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string DescripcionLibro { get; set; }
        public decimal Costo { get; set; }
        public string Estado { get; set; }

    }

    public class DesactivadorModel
    {
        public int IdLibro { get; set; }
        public string Estado { get; set; }

    }

    public class ActivadorModel
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string DescripcionLibro { get; set; }
        public string Estado { get; set; }

    }


}
