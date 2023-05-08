using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Zasoby
    {
        [Key]
        [Column("ZasobyId")]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string typ { get; set; }
        public int id_projektu { get; set; }
        
        public virtual Projekty Projekty { get; set; }
    }
}