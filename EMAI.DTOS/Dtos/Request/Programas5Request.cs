using Microsoft.AspNetCore.Http;

namespace EMAI.DTOS.Dtos.Request
{
    public class Programas5Request
    {
        public string Area { get; set; }
        public string Supervisor { get; set; }
        public IFormFile ImagenAntes { get; set; }
        public DateTime FechaSubidaAntes { get; set; }
        public IFormFile ImagenDespues { get; set; }
        public DateTime FechaSubidaDespues { get; set; }
        public string Detalles { get; set; }
    }
}
