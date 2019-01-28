using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SystemRezerwacji.Models;

namespace SystemRezerwacji.Models
{
    public class Rezerwacja
    {
        public int Id { get; set; }
        public int PolaczenieID { get; set; }
        public int PodroznyID { get; set; }

        [Display(Name = "Status")]
        public string StatusRezerwacjiId { get; set; }

        public virtual ICollection<Podrozny> Podrozni { get; set; } //Rezerwacja chce widzieć kolekcję Podróżny
        public virtual ICollection<Polaczenie> Polaczenia { get; set; } //Rezerwacja chce widzieć kolekcję Polaczenia
        public virtual StatusRezerwacji StatusyRezerwacji { get; set; } //Rezerwacja pobiera Status z innej tabeli
    }
}