namespace emai.Models
{
    public class RepClase
    {
            public int IdRepClase { get; set; }
            public int IdAlumno { get; set; }
            public int IdMaestro { get; set; }
            public int IdClase { get; set; }
            public string DiaRep { get; set; }
             public List<RepClase> Lista{ get; set; }
             public List<Maestro> MaestrosDisponibles { get; set; }
            public List<Clase> ClasesDisponibles { get; set; }
            public string NombreClase { get; internal set; }
        public string NombreMaestro { get; internal set; }
    }
}
