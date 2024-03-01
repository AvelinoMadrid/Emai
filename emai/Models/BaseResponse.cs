using emai.Servicios;

namespace emai.Models
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public List<AlumnoModel> Data { get; set; }
        public string? Message { get; set; }

    }
}
