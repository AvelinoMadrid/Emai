using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emai.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string DescripcionLibro { get; set; }
        public decimal Costo { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
        public List<Libro> Lista { get; set; }
    }
}
