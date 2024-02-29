namespace emai.Models
{
    public class Promosionestrecutura <Promosiones>
    {
        public bool IsSuccess { get; set; }
        public Promosiones? Data { get; set; }
        public string? Message { get; set; }
    }
}
