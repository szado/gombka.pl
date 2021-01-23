# Gombka.pl
Portal umo¿liwiaj¹cy proste udostêpnianie wideo w internecie.

## Instalacja
- utwórz now¹ bazê danych na SqlServer i zmodyfikuj odpowiednio appsettings.json (domyœlna instancja to "dev", baza "gombkadb")
- `dotnet tool install --global dotnet-ef` (za pierwszym razem)
- `dotnet ef database update` (wykonanie migracji)