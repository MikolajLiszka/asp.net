KONFIGURACJA APLIKACJI
1. Utwórz nową bazę danych pod nazwą np. wypozyczalnia_gier.
2. Zmodifikuj plik appsettings.json ustawiając połączenie do bazy danych w ścieżce 
"AppIdentity": {
      "ConnectionString": "Data Source=Server;Initial Catalog=wypozyczalnia_gier;Integrated Security=True"
    },
oraz
"Gry": {
      "ConnectionString": "Data Source=Server;Initial Catalog=wypozyczalnia_gier;Integrated Security=True"
    }
Data Source - zmień na nazwę swojego połączenia z serwerem bazodanowym oraz jeżeli twoja baza danych nazywa się inaczej niż wypozyczalnia_gier, w miejscu Catalog - wpisz nazwę bazy danych
3. Otwórz konsolę NuGet i wykonaj migracje komedami:
- add-migration <nazwa-migracji>
- update-database –verbose
4. Następnie można już otworzyć aplikacje
5. Aby dodać, edytować lub usunąć grę, kategorię lub dewelopera gry, należy się najpierw zarejestrować wybierając z menu opcję Rejestruj, a potem być zalogowanym opcją Loguj.

