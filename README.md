# Dokumentacja Projektu Serwisu Muzycznego

**Autor:** Kacper Kozicki

## Wprowadzenie

Projekt realizuje serwis muzyczny w technologii ASP.NET, oferujący funkcjonalności zarządzania piosenkami, albumami oraz playlistami. Umożliwia tworzenie, edycję i usuwanie treści muzycznych, a także przeglądanie i odkrywanie nowych utworów poprzez zaawansowane filtrowanie i wyszukiwanie.

## Wykorzystane Technologie

- ASP.NET Core 6.0
- Baza danych: SQLite
- Entity Framework Core - dla operacji na bazie danych
- LINQ – dla zapytań do bazy danych
- Identity Framework – dla autentykacji i zarządzania rolami użytkowników

## Przykładowi Użytkownicy

### Administrator

- Login: adam@wsei.edu.pl
- Hasło: Admin123#
- Rola: ADMIN

### Artysta

- Login: michael@wsei.edu.pl
- Hasło: Michael123#
- Rola: ARTIST

### Zwykły użytkownik

- Login: tomek@wsei.edu.pl
- Hasło: Tomek123#
- Rola: USER

### Zwykły użytkownik

- Login: julia@wsei.edu.pl
- Hasło: Julia#
- Rola: USER

## Proces Uruchomienia Aplikacji

1. **Klonowanie repozytorium:** Sklonuj repozytorium z GitHub.
2. **Instalacja zależności:** Użyj `dotnet restore` w katalogu projektu, aby zainstalować zależności.
3. **Migracja bazy danych:** Uruchom `dotnet ef database update`, aby zastosować migracje do bazy danych SQLite.
4. **Uruchomienie aplikacji:** Użyj `dotnet run` w katalogu projektu, aby uruchomić aplikację.

## Opis Funkcjonalności

- **Albumy:** Użytkownicy z rolą ARTIST mogą tworzyć albumy, których są autorami. Administrator może tworzyć albumy różnych artystów.

- **Piosenki:** Możliwość dodawania piosenek do albumów przez użytkowników z odpowiednimi uprawnieniami.

- **Playlisty:** Użytkownicy mogą tworzyć, edytować i usuwać swoje playlisty. Mogą decydować o ich statusie publicznym lub prywatnym.

- **Odkrywanie Muzyki:** Funkcja wyszukiwania z filtrowaniem po piosenkach, albumach, playlistach i wszystkich kategoriach.

- **API:** Wykorzystanie WebAPI do dynamicznego pobierania danych z bazy i generowania podpowiedzi.

- **Zabezpieczenia:** Zapobieganie tworzeniu duplikatów (np. playlist o tych samych nazwach) oraz weryfikacja istnienia piosenek w bazie podczas dodawania do playlisty.

- **Cookie:** Ciasteczko odpowiedzialne za sprawdzanie wizyt na stronie oraz informowaniu o ostatnich odwiedzinach
