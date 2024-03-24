using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.DTOS.Dtos.Response
{
    public class Programas5Response
    {
        public int Id { get; set; }
        public string Area { get; set; } = string.Empty;
        public string Supervisor { get; set; } = string.Empty;
        public string ImagenAntes { get; set; } = string.Empty;
        public DateTime FechaSubidaAntes { get; set; }
        public string ImagenDespues { get; set; } = string.Empty;
        public DateTime FechaSubidaDespues { get; set; }
        public string Detalles { get; set; } = string.Empty;
    }
}
