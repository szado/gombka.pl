# Gombka.pl
Portal umożliwiający proste udostępnianie wideo w internecie.

## Instalacja
- utwórz nową bazę danych na SqlServer i zmodyfikuj odpowiednio appsettings.json (domyślna instancja to "dev", baza "Gombkapl")
- `dotnet tool install --global dotnet-ef` (za pierwszym razem)
- `dotnet ef database update` (wykonanie migracji)
- upewnij sie, że ścieżka zdefiniowana w appsettings.json pod kluczem `StoredFilesPath` jest poprawna, istnieje i ma nadane odpowiednie uprawnienia do zapisu i odczytu