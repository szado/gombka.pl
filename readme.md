# Gombka.pl
Portal umo�liwiaj�cy proste udost�pnianie wideo w internecie.

## Instalacja
- utw�rz now� baz� danych na SqlServer i zmodyfikuj odpowiednio appsettings.json (domy�lna instancja to "dev", baza "gombkadb")
- `dotnet tool install --global dotnet-ef` (za pierwszym razem)
- `dotnet ef database update` (wykonanie migracji)