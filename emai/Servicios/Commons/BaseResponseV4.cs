namespace emai.Servicios.Commons
{
    public class BaseResponseV4<Generica>
    {
        public bool IsSuccess { get; set; }
        public Generica? Data { get; set; } ///AlumModel
        public string? Message { get; set; }
    }
}
