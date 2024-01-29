namespace EMAI.Comun.Models
{
    public class EventosModel
    {
        public int IdEvento { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public int IdHora { get; set; }
        public string NameHora {  get; set; }
        public string Fecha { get; set; }
        public string NombreEvento { get; set; }
        public string NombreAlumno {  get; set; }
        public string ApellidoP { get;  set; }
        public string ApellidoM { get; set; }
        public string NombreClase { get; set; }


    }

    public class EventosIDModel
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public int IdHora { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public string Fecha { get; set; }
        public string NameHora { get; set; }

        public class EventoInsertarModel
        {
            public string NombreEvento { get; set; }
            public DateTime Fecha { get; set; }
            public int IdHora { get; set; }
            public int IdAlumno { get; set; }
            public int IdClase { get; set; }
        }

        public class EventosActualizarModel
        {
            public int IdEvento { get; set; }
            public int IdAlumno { get; set; }
            public int IdClase { get; set; }
            public int IdHora { get; set; }
            public string Fecha { get; set; }
            public string NombreEvento { get; set; }
        }

        public class EventosEliminarModel
        {
            public int IdEvento { get; set; }
            public string NombreEvento { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime Hora { get; set; }
            public int IdAlumno { get; set; }
            public int IdClase { get; set; }
        }
    }
}
