# Gombka.pl
Portal umożliwiający proste udostępnianie wideo w internecie.

## Instalacja
1. utwórz nową bazę danych na SqlServer i zmodyfikuj odpowiednio appsettings.json (domyślna instancja to "dev", baza "Gombkapl")
2. `dotnet tool install --global dotnet-ef` (za pierwszym razem)
3. `dotnet ef database update` (wykonanie migracji)
4. upewnij sie, że ścieżki zdefiniowane w appsettings.json są poprawne: <br>
* `StoredFilesPath` - przetrzymywane pliki wideo
* `StoredThumbnailsPath` - przetrzymywane miniaturki wideo
* `FFMPEGExecutablePath` - binarki programu FFMPEG
