using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemRezerwacji.Models
{
    public class Relacja
    {
        public int Id { get; set; }

        [Display(Name = "Stacja początkowa")]
        public string Stacja_poczatkowa { get; set; }

        public string Stacja_koncowa { get; set; }
        public string Stacja_posrednia { get; set; }

        [Required(ErrorMessage = "uzupełnij odległość")]
        public int Odleglosc { get; set; }

        public virtual ICollection<Polaczenie> Polaczenia { get; set; }
    }
}