using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Projekty
    {
        [Key]
        [Column("ProjektyId")]
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public DateTime data_startu { get; set; }
        public DateTime? data_zakonczenia { get; set; }
        public int? id_kierownika_projektu { get; set; }
        public string status { get; set; }

        
        public virtual Uzytkownicy KierownikProjektu { get; set; }
        public virtual  ICollection<Uzytkownicy> UzytkownicyCollection { get; set; } = new List<Uzytkownicy>();
        public virtual ICollection<Zadania> ZadaniaCollection { get; set; } = new List<Zadania>();
        public virtual  ICollection<Zasoby> ZasobyCollection { get; set; } = new List<Zasoby>();

    }
}