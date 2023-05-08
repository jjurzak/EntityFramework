using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Zmiany_uzytkownika
    {
    [Key]
    [Column("Zmiany_uzytkownikaId")]
    public int Id_uzytkownika { get; set; }
    public int id_historia_zmian { get; set; }
    public DateTime data_zmiany { get; set; }
    
    public virtual Historia_zmian Historia_zmian { get; set; }
    public virtual Uzytkownicy Uzytkownicy { get; set; }
    }
}