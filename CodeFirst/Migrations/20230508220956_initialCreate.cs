using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoriaZmian",
                columns: table => new
                {
                    Historia_zmianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_zmiany = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaZmian", x => x.Historia_zmianId);
                });

            migrationBuilder.CreateTable(
                name: "Projekty",
                columns: table => new
                {
                    ProjektyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_startu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_zakonczenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_kierownika_projektu = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekty", x => x.ProjektyId);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    UzytkownicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_projektu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.UzytkownicyId);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Projekty_id_projektu",
                        column: x => x.id_projektu,
                        principalTable: "Projekty",
                        principalColumn: "ProjektyId");
                });

            migrationBuilder.CreateTable(
                name: "Zasoby",
                columns: table => new
                {
                    ZasobyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_projektu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zasoby", x => x.ZasobyId);
                    table.ForeignKey(
                        name: "FK_Zasoby_Projekty_id_projektu",
                        column: x => x.id_projektu,
                        principalTable: "Projekty",
                        principalColumn: "ProjektyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrzeznaczenieWiadomosci",
                columns: table => new
                {
                    Przeznaczenie_wiadomosciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_odbiorcy = table.Column<int>(type: "int", nullable: false),
                    Tresc_wiadomosci = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrzeznaczenieWiadomosci", x => x.Przeznaczenie_wiadomosciId);
                    table.ForeignKey(
                        name: "FK_PrzeznaczenieWiadomosci_Uzytkownicy_id_odbiorcy",
                        column: x => x.id_odbiorcy,
                        principalTable: "Uzytkownicy",
                        principalColumn: "UzytkownicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Raporty",
                columns: table => new
                {
                    RaportyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    czas_pracy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    koszt = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raporty", x => x.RaportyId);
                    table.ForeignKey(
                        name: "FK_Raporty_Uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "Uzytkownicy",
                        principalColumn: "UzytkownicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zadania",
                columns: table => new
                {
                    ZadaniaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_startu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_zakonczenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_projektu = table.Column<int>(type: "int", nullable: false),
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadania", x => x.ZadaniaId);
                    table.ForeignKey(
                        name: "FK_Zadania_Projekty_id_projektu",
                        column: x => x.id_projektu,
                        principalTable: "Projekty",
                        principalColumn: "ProjektyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zadania_Uzytkownicy_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "Uzytkownicy",
                        principalColumn: "UzytkownicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZmianyUzytkownika",
                columns: table => new
                {
                    Zmiany_uzytkownikaId = table.Column<int>(type: "int", nullable: false),
                    id_historia_zmian = table.Column<int>(type: "int", nullable: false),
                    data_zmiany = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZmianyUzytkownika", x => x.Zmiany_uzytkownikaId);
                    table.ForeignKey(
                        name: "FK_ZmianyUzytkownika_HistoriaZmian_id_historia_zmian",
                        column: x => x.id_historia_zmian,
                        principalTable: "HistoriaZmian",
                        principalColumn: "Historia_zmianId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZmianyUzytkownika_Uzytkownicy_Zmiany_uzytkownikaId",
                        column: x => x.Zmiany_uzytkownikaId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "UzytkownicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wiadomosci",
                columns: table => new
                {
                    WiadomosciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_nadawcy = table.Column<int>(type: "int", nullable: false),
                    PrzeznaczenieWiadomosciPrzeznaczenie_wiadomosciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wiadomosci", x => x.WiadomosciId);
                    table.ForeignKey(
                        name: "FK_Wiadomosci_PrzeznaczenieWiadomosci_PrzeznaczenieWiadomosciPrzeznaczenie_wiadomosciId",
                        column: x => x.PrzeznaczenieWiadomosciPrzeznaczenie_wiadomosciId,
                        principalTable: "PrzeznaczenieWiadomosci",
                        principalColumn: "Przeznaczenie_wiadomosciId");
                    table.ForeignKey(
                        name: "FK_Wiadomosci_Uzytkownicy_id_nadawcy",
                        column: x => x.id_nadawcy,
                        principalTable: "Uzytkownicy",
                        principalColumn: "UzytkownicyId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_id_kierownika_projektu",
                table: "Projekty",
                column: "id_kierownika_projektu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrzeznaczenieWiadomosci_id_odbiorcy",
                table: "PrzeznaczenieWiadomosci",
                column: "id_odbiorcy");

            migrationBuilder.CreateIndex(
                name: "IX_Raporty_id_uzytkownika",
                table: "Raporty",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_id_projektu",
                table: "Uzytkownicy",
                column: "id_projektu");

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosci_id_nadawcy",
                table: "Wiadomosci",
                column: "id_nadawcy");

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosci_PrzeznaczenieWiadomosciPrzeznaczenie_wiadomosciId",
                table: "Wiadomosci",
                column: "PrzeznaczenieWiadomosciPrzeznaczenie_wiadomosciId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadania_id_projektu",
                table: "Zadania",
                column: "id_projektu");

            migrationBuilder.CreateIndex(
                name: "IX_Zadania_id_uzytkownika",
                table: "Zadania",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Zasoby_id_projektu",
                table: "Zasoby",
                column: "id_projektu");

            migrationBuilder.CreateIndex(
                name: "IX_ZmianyUzytkownika_id_historia_zmian",
                table: "ZmianyUzytkownika",
                column: "id_historia_zmian");

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_Uzytkownicy_id_kierownika_projektu",
                table: "Projekty",
                column: "id_kierownika_projektu",
                principalTable: "Uzytkownicy",
                principalColumn: "UzytkownicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projekty_Uzytkownicy_id_kierownika_projektu",
                table: "Projekty");

            migrationBuilder.DropTable(
                name: "Raporty");

            migrationBuilder.DropTable(
                name: "Wiadomosci");

            migrationBuilder.DropTable(
                name: "Zadania");

            migrationBuilder.DropTable(
                name: "Zasoby");

            migrationBuilder.DropTable(
                name: "ZmianyUzytkownika");

            migrationBuilder.DropTable(
                name: "PrzeznaczenieWiadomosci");

            migrationBuilder.DropTable(
                name: "HistoriaZmian");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Projekty");
        }
    }
}
