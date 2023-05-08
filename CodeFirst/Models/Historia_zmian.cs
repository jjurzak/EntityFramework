using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Historia_zmian
    {
    [Key]
    [Column("Historia_zmianId")]
    public int Id { get; set; }
    public int id_uzytkownika { get; set; }
    public string opis { get; set; }
    public DateTime data_zmiany { get; set; }
    
    public virtual ICollection<Zmiany_uzytkownika> ZmianyUzytkownikaCollection { get; set; } = new List<Zmiany_uzytkownika>();

    }
}