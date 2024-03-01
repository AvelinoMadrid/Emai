namespace emai.Models
{
    public class MesesModel
    {
        public int IdMeses { get; set; }
        public string NombreMes { get; set; } = null!;
        public List<MesesModel> Meses {get;set;}
    }
}
