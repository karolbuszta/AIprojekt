using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemRezerwacji.Models
{
    public class Polaczenie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "uzupełnij relację")]
        [Display(Name = "Relacja")]
        public int RelacjaId { get; set; }

        public DateTime Czas_odjazdu { get; set; }
        public DateTime Czas_przyjazdu { get; set; }
        public string Kategoria { get; set; }
        public int Cena { get; set; }

        public virtual Relacja Relacje { get; set; }
        public virtual ICollection<Rezerwacja> Rezerwacje { get; set; }
    }
}