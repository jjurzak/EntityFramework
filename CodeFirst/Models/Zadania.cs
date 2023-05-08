using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Zadania
    {
    [Key]
    [Column("ZadaniaId")]
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public DateTime data_startu { get; set; }
    public DateTime? data_zakonczenia { get; set; }
    public int id_projektu { get; set; }
    public int id_uzytkownika { get; set; }
    public string status { get; set; }
    
    
    public virtual Projekty Projekty { get; set; }
    public virtual Uzytkownicy Uzytkownicy { get; set; }
    }
}