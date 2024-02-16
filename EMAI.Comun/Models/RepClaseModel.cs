using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class RepClaseModel
    {
        public int IdRepClase { get; set; }
        public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string DiaRep { get; set; }
        

    public class RepClaseIDModel
        {
        public int IdRepClase { get; set; }
        public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string DiaRep { get; set; }
    }

    public class RepClaseInsertarModel
        {
            public int IdAlumno { get; set; }
            public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string DiaRep { get; set; }
    }

    public class RepClaseActualizarModel
        {
        public int IdRepClase { get; set; }
        public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string DiaRep { get; set; }
 
    }

    public class RepClaseEliminarModel
        {
        public int IdRepClase { get; set; }
        public int IdAlumno { get; set; }
        public int IdMaestro { get; set; }
        public int IdClase { get; set; }
        public string DiaRep { get; set; }
 
    }
}
}

