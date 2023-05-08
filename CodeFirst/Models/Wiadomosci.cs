using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Wiadomosci
    {
    [Key]
    [Column("WiadomosciId")]
    public int Id { get; set; }
    public string Tytul { get; set; }
    public string Tresc { get; set; }
    public int id_nadawcy { get; set; }
    
    public virtual Uzytkownicy Nadawca { get; set; }
    
    }
}