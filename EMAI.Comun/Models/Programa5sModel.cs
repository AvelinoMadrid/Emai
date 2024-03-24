using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class Programa5sModel
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Supervisor { get; set; }
        public DateTime FechaAntes { get; set; }
        public DateTime FechaInicio { get; set; }
        public string ImagenAntes { get; set; }
        public string ImagenDespues { get; set; }
        public string Detalles { get; set; }

    }

    public class Programa5sIdModel
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Supervisor { get; set; }
        public DateTime FechaAntes { get; set; }
        public DateTime FechaInicio { get; set; }
        public string ImagenAntes { get; set; }
        public string ImagenDespues { get; set; }
        public string Detalles { get; set; }

    }

    public class Programa5sInsertarModel
    {
        public string Area { get; set; }
        public string Supervisor { get; set; }
        public DateTime FechaAntes { get; set; }
        public DateTime FechaInicio { get; set; }
        public string ImagenAntes { get; set; }
        public string ImagenDespues { get; set; }
        public string Detalles { get; set; }

    }

    public class Programa5sActualizarModel
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Supervisor { get; set; }
        public DateTime FechaAntes { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Detalles { get; set; }

    }
    public class Programa5ModelV1
    {
        public int Id { get; set; }
        public string Area { get; set; }=string.Empty;
        public string Supervisor { get; set; }= string.Empty; 
        public string ImagenAntes { get; set; } = string.Empty;
        public DateTime FechaSubidaAntes { get; set; }
        public int Intentos1 { get; set; }
        public string ImagenDespues { get; set; } = string.Empty;
        public DateTime FechaSubidaDespues { get; set; }
        public int Intentos2 { get; set; }
        public string Detalles { get; set; } = string.Empty;
    }

}
