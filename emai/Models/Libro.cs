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
        public decimal costo { get; set; }
        public bool Status { get; set; }
        public List<Libro> Lista { get; set; }
    }
}
