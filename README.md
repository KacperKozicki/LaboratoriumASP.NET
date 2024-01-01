# Dokumentacja Projektu Serwisu Muzycznego

## Autor: Kacper Kozicki

---

## Wprowadzenie

Projekt realizuje serwis muzyczny w technologii ASP.NET, oferujący funkcjonalności zarządzania piosenkami, albumami oraz playlistami. Umożliwia tworzenie, edycję i usuwanie treści muzycznych, a także przeglądanie i odkrywanie nowych utworów poprzez zaawansowane filtrowanie i wyszukiwanie.

**Nota:** Aplikacja zawiera załadowane przykładowe dane dla celów demonstracyjnych.

---

## Wykorzystane Technologie

- ASP.NET Core 6.0
- Baza danych: SQLite
- Entity Framework Core - dla operacji na bazie danych
- LINQ – dla zapytań do bazy danych
- Identity Framework – dla autentykacji i zarządzania rolami użytkowników

---
Aby uruchomić tę aplikację ASP.NET, musisz spełnić następujące wymagania:

1. **.NET 6.0**: Upewnij się, że masz zainstalowane środowisko .NET w wersji 6.0. Możesz pobrać je ze strony [oficjalnej witryny .NET](https://dotnet.microsoft.com/download/dotnet/6.0).

2. **Entity Framework**: Aplikacja korzysta z frameworka Entity Framework, dlatego konieczne jest zainstalowanie odpowiedniej wersji tego narzędzia.

---
Projekt wykorzystuje następujące pakiety NuGet:

- **Microsoft.EntityFrameworkCore** w wersji 7.0.13: Główna biblioteka Entity Framework Core, która umożliwia dostęp do bazy danych i mapowanie obiektowo-relacyjne.

- **Microsoft.EntityFrameworkCore.Design** w wersji 7.0.13: Pakiet ten zawiera narzędzia projektowe (np. polecenia CLI) do zarządzania migracjami i modelem danych w Entity Framework Core.

- **Microsoft.EntityFrameworkCore.Sqlite** w wersji 7.0.13: Ten pakiet pozwala korzystać z bazy danych SQLite w ramach aplikacji, co może być przydatne do przechowywania danych lokalnie.

- **Microsoft.AspNetCore.Identity.EntityFrameworkCore** w wersji 6.0.25: Ten pakiet jest częścią ASP.NET Core Identity i pozwala na zarządzanie kontami użytkowników, uwierzytelnianie i autoryzację w aplikacji.

---

## Użytkownicy

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

---

## Proces Uruchomienia Aplikacji

1. **Klonowanie repozytorium:** Sklonuj repozytorium z GitHub.
2. **Instalacja zależności:** Użyj `dotnet restore` w katalogu projektu, aby zainstalować zależności.
3. **Migracja bazy danych:** Uruchom `dotnet ef database update`, aby zastosować migracje do bazy danych SQLite.
4. **Uruchomienie aplikacji:** Użyj `dotnet run` w katalogu projektu, aby uruchomić aplikację.

---

## Opis Funkcjonalności

- **Albumy:** Użytkownicy z rolą ARTIST mogą tworzyć albumy, których są autorami. Administrator może tworzyć albumy różnych artystów.

- **Piosenki:** Możliwość dodawania piosenek do albumów przez użytkowników z odpowiednimi uprawnieniami.

- **Playlisty:** Użytkownicy mogą tworzyć, edytować i usuwać swoje playlisty. Mogą decydować o ich statusie publicznym lub prywatnym.

- **Odkrywanie Muzyki:** Funkcja wyszukiwania z filtrowaniem po piosenkach, albumach, playlistach i wszystkich kategoriach.

- **API:** Wykorzystanie WebAPI do dynamicznego pobierania danych z bazy i generowania podpowiedzi.

- **Zabezpieczenia:** Zapobieganie tworzeniu duplikatów (np. playlist o tych samych nazwach) oraz weryfikacja istnienia piosenek w bazie podczas dodawania do playlisty.
  
- **Cookie:** Ciasteczko odpowiedzialne za sprawdzanie wizyt na stronie oraz informowaniu o ostatnich odwiedzinach
---

## Szczegóły Funkcjonalności

### Zakładka Playlist

- **Wgląd w Własne Playlisty:** Użytkownicy mają dostęp wyłącznie do swoich playlist, co zapewnia prywatność i personalizację treści.

- **Tworzenie Playlist:** Możliwość tworzenia nowych playlist, w tym dodawania utworów z dostępnej bazy danych.

- **Edycja i Usuwanie Playlist:** Użytkownicy mogą edytować nazwy, opisy oraz zawartość swoich playlist, a także je usuwać.

- **Ustawienia Prywatności Playlist:** Podczas tworzenia playlisty użytkownik decyduje, czy ma być ona publiczna czy prywatna.

### Zakładka Odkrywaj

- **Wyszukiwarka z Filtrowaniem:** Zaawansowana funkcja wyszukiwania z filtrami (piosenki, albumy, playlisty, wszystko).

- **Dynamiczne Wyszukiwanie za Pomocą API:** Wyszukiwarka korzysta z WebAPI do pobierania wyników z bazy danych w czasie rzeczywistym.

- **Szczegółowe Informacje o Wynikach:** Po wybraniu wyniku, użytkownicy mogą przeglądać szczegółowe informacje, takie jak lista utworów w albumie czy szczegóły playlisty.

- **Łącza do Powiązanych Treści:** Możliwość przejścia do powiązanych treści, np. po wybraniu playlisty użytkownik może przeglądać poszczególne utwory i odkrywać inne piosenki tego samego wykonawcy.

---

## Bezpieczeństwo i Optymalizacja

- **Zabezpieczenie Przed Duplikatami:** System zapobiega tworzeniu playlist o identycznych nazwach.

- **Walidacja Istnienia Utworów:** Podczas dodawania utworów do playlisty, system sprawdza, czy wybrane utwory istnieją w bazie danych.

- **Sugerowanie Utworów:** API wykorzystywane jest również do sugerowania utworów użytkownikowi podczas tworzenia lub edycji playlisty.


