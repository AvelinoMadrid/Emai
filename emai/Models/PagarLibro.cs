namespace emai.Models
{
    public class PagarLibro
    {
        public int IdPagarLibro { get; set; }
        public int IdAlumno{ get; set; }
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalPagado { get; set; }
        public List<PagarLibro> Lista { get; set; }
        public List<Alumnos> AlumnoDisponible { get; set; }
        public List<Libro> LibroDisponible { get; set; }
    }
}
