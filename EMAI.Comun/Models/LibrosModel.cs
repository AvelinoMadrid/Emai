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
        public decimal costo { get; set; }
        public bool Status { get; set; }
    }

    public class InsertLibrosModel
    {
        public string NombreLibro { get; set; }
        public decimal costo { get; set; }
        public bool Status { get; set;}
    }

    public class LibrosUpModel
    {
        public int IdLibro { get; set; }
        //public bool Status { get; set; }
        public decimal Costo { get; set; }

    }

    public class DesactivadorModel
    {
        public int IdLibro { get; set; }

    }


}
