namespace NaukaMVC.Entities
{
    public class RecenzjaEntity
    {
        public int Id { get; set; }
        public string Wiadomosc { get; set; } = default!;
        public string Autor { get; set; } = default!;   
        public DateTime DataDodania { get; set; } = default!;
    }
}
