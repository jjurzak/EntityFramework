using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models;

public class Uzytkownicy
{
    [Key]
    [Column("UzytkownicyId")]
    public int Id { get; set; }

    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Email { get; set; }
    public string login { get; set; }
    public string haslo { get; set; }
    public string typ { get; set; }
    public int? id_projektu { get; set; }
    
    public virtual Projekty Projekt { get; set; }
    

    public virtual Projekty ProjektyCollection { get; set; } = null!;
    public virtual ICollection<Zadania> ZadaniaCollection { get; set; } = new List<Zadania>();
    public virtual ICollection<Wiadomosci> WiadomosciCollection { get; set; } = new List<Wiadomosci>();
    public virtual ICollection<Raporty> RaportyCollection { get; set; } = new List<Raporty>();
    public virtual ICollection<PrzeznaczenieWiadomosci> PrzeznaczenieWiadomosciCollection { get; set; } = new List<PrzeznaczenieWiadomosci>();
    public virtual ICollection<Zmiany_uzytkownika> ZmianyUzytkownikaCollection { get; set; } = new List<Zmiany_uzytkownika>();
}