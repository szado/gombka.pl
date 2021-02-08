# Gombka.pl
Portal umożliwiający proste udostępnianie wideo w internecie.

## Instalacja
- utwórz nową bazę danych na SqlServer i zmodyfikuj odpowiednio appsettings.json (domyślna instancja to "dev", baza "Gombkapl")
- `dotnet tool install --global dotnet-ef` (za pierwszym razem)
- `dotnet ef database update` (wykonanie migracji)
- upewnij sie, że ścieżki zdefiniowane w appsettings.json są poprawne: <br>
* `StoredFilesPath` - przetrzymywane pliki wideo
* `StoredThumbnailsPath` - przetrzymywane miniaturki wideo
* `FFMPEGExecutablePath` - binarki programu FFMPEG
