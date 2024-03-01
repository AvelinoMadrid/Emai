using emai.Models;

namespace emai.Servicios.Commons
{
    public class BaseResponseV1<Generica>
    {
        public bool IsSuccess { get; set; }
        public List<Generica>? Data { get; set; }
        public string? Message { get; set; }

        
      //  public BaseResponseV1<AlumnoModel> ListarAllAlumnos { get; set; }
    }
}
