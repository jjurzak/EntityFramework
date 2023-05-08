using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace CodeFirst.Models

{
    public class Raporty
    {
    [Key]
    [Column("RaportyId")]
    public int Id { get; set; }
    public int id_uzytkownika { get; set; }
    public string Tytul { get; set; }
    public string Tresc { get; set; }
    public DateTime czas_pracy { get; set; }
    public Decimal koszt { get; set; }
    
    public virtual Uzytkownicy Uzytkownicy { get; set; }
    }
}