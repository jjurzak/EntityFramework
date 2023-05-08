using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class SzpContext : DbContext
    {
        public SzpContext()
        {
        }

        public SzpContext(DbContextOptions<SzpContext> options)
            : base(options)
        {
        }
        
        
        public virtual DbSet<Projekty> Projekty { get; set; }
        public virtual DbSet<Zadania> Zadania { get; set; }
        public virtual DbSet<Zasoby> Zasoby { get; set; }
        public virtual DbSet<Uzytkownicy> Uzytkownicy { get; set; }
        public virtual DbSet<Wiadomosci> Wiadomosci { get; set; }
        public virtual DbSet<Raporty> Raporty { get; set; }
        public virtual DbSet<Historia_zmian> HistoriaZmian { get; set; }
        public virtual DbSet<Zmiany_uzytkownika> ZmianyUzytkownika { get; set; }
        public virtual DbSet<PrzeznaczenieWiadomosci> PrzeznaczenieWiadomosci { get; set; }

        //
        // public virtual DbSet<Airport> Airports { get; set; }
        // public virtual DbSet<Airplane> Airplanes { get; set; }
        // public virtual DbSet<FlightLog> FlightLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SZP-final2;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Projekty>()
                .HasOne(e => e.KierownikProjektu)
                .WithOne(e => e.Projekt)
                .HasForeignKey<Projekty>(e => e.id_kierownika_projektu)
                .OnDelete(DeleteBehavior.NoAction) // 
                .HasConstraintName("FK_Projekty_Uzytkownicy_id_kierownika_projektu");
                

            modelBuilder.Entity<Projekty>()
                .HasMany(e => e.UzytkownicyCollection)
                .WithOne(e => e.ProjektyCollection)
                .HasForeignKey(e => e.id_projektu);

            modelBuilder.Entity<Zadania>()
                .HasOne(e => e.Projekty)
                .WithMany(e => e.ZadaniaCollection)
                .HasForeignKey(e => e.id_projektu);
            
            modelBuilder.Entity<Zadania>()
                .HasOne(e => e.Uzytkownicy)
                .WithMany(e => e.ZadaniaCollection)
                .HasForeignKey(e => e.id_uzytkownika);
            
            modelBuilder.Entity<Zasoby>()
                .HasOne(e => e.Projekty)
                .WithMany(e => e.ZasobyCollection)
                .HasForeignKey(e => e.id_projektu);
            
            modelBuilder.Entity<Wiadomosci>()
                .HasOne(e => e.Nadawca)
                .WithMany(e => e.WiadomosciCollection)
                .HasForeignKey(e => e.id_nadawcy);
            
            modelBuilder.Entity<Raporty>()
                .HasOne(e => e.Uzytkownicy)
                .WithMany(e => e.RaportyCollection)
                .HasForeignKey(e => e.id_uzytkownika);

            modelBuilder.Entity<Zmiany_uzytkownika>()
                .HasOne(e => e.Historia_zmian)
                .WithMany(e => e.ZmianyUzytkownikaCollection)
                .HasForeignKey(e => e.id_historia_zmian);

            modelBuilder.Entity<Wiadomosci>()
                .HasOne(e => e.Nadawca)
                .WithMany(e => e.WiadomosciCollection)
                .HasForeignKey(e => e.id_nadawcy).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PrzeznaczenieWiadomosci>()
                .HasOne(e => e.Uzytkownicy)
                .WithMany(e => e.PrzeznaczenieWiadomosciCollection)
                .HasForeignKey(e => e.id_odbiorcy);

            modelBuilder.Entity<Zmiany_uzytkownika>()
                .HasOne(e => e.Uzytkownicy)
                .WithMany(e => e.ZmianyUzytkownikaCollection)
                .HasForeignKey(e => e.Id_uzytkownika);
            
            modelBuilder.Entity<Uzytkownicy>()
                .HasMany(u => u.ZmianyUzytkownikaCollection)
                .WithOne(z => z.Uzytkownicy)
                .HasForeignKey(z => z.Id_uzytkownika);

        }
    }
}
