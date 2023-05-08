using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class PrzeznaczenieWiadomosci
    {
        [Key]
        [Column("Przeznaczenie_wiadomosciId")]
        public int Przeznaczenie_wiadomosciId { get; set; }
        public int id_odbiorcy { get; set; }
        public string Tresc_wiadomosci { get; set; }
    
    public virtual ICollection<Wiadomosci> Wiadomosci { get; set; } = new List<Wiadomosci>();
    public virtual Uzytkownicy Uzytkownicy { get; set; }
    }
}