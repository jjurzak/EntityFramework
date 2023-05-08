
# PROJEKT ENTITY FRAMEWORK

## Plik główny SzpContext

W tym pliku znajdują się klasy, dbcontexty odpowiadajace za utowrzenie tabeli jak i utowrzone relacje pomiędzy poszczegolnymi tabelami (plikami).

## Pliki poboczne odpowiadajace za tabele 

### Historia_zmian

zawiera informacje o zmianach dokonanych przez uzytkownika

### Projekty

zawiera informacje takie jak nazwa, opis data startu/końca projektu. Zawiera id kierownika projektu.

### PrzeznaczenieWiadomosci

Tabela pomocniczca dla tabeli Wiadomosci.

### Raporty

Zawiera raporty uzytkownikow odnosnie postepow w projektach jak i koszta finansowe.

### Uzytkownicy

Informacje o użytkownikach Imię, nazwisko, login - hasło, email do jakiego projektu są przypisani lub nie.

### Wiadomosci

Tabela zawierajaca informacje kto i do kogo wysłał wiadomosc z jakas treścią i tytułem.

### Zadania

Tabela posiadająca takie pola jak id, nazwa opis czy daty startu i zakonczenia tasku. Dzięki tej tabeli wiemy kto jest przypisany do danego taska i jakiego projektu dotyczą owe taski.

### Zasoby

Tabela informująca jakie zasoby są potrzebne przy danym projekcie pola w tej tabeli to nazwa, opis typ i przypisanie do projektu.

### Zmiany użytkownika 

Dzięki tej tabeli wiemy jakie zmiany poczynił użytkownik.


