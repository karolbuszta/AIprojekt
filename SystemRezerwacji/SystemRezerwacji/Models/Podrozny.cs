namespace SystemRezerwacji.Models
{
    public class Podrozny
    {
        public int Id { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Email { get; set; }

        public virtual Rezerwacja Rezerwacje { get; set; } //udostępnienie Rezerwacjom kolekcji Podróżny
    }
}