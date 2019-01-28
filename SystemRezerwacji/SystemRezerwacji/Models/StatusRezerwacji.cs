using System.Collections.Generic;

namespace SystemRezerwacji.Models
{
    public class StatusRezerwacji
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Rezerwacja> Rezerwacje { get; set; } //Rezerwacja chce widzieć kolekcję Polaczenia
    }
}