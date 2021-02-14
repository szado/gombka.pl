# Gombka.pl
Portal umożliwiający proste udostępnianie wideo w internecie.

## Instalacja
1. utwórz nową bazę danych na SqlServer i zmodyfikuj odpowiednio appsettings.json (domyślna instancja to "dev", baza "Gombkapl")
2. `dotnet tool install --global dotnet-ef` (za pierwszym razem)
3. `dotnet ef database update` (wykonanie migracji)
4. Ściągnij binarki programu FFMPEG (źródło dla Windows 10: `https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-full.7z`)
6. upewnij sie, że ścieżki zdefiniowane w appsettings.json są poprawne:
* `StoredFilesPath` - przetrzymywane pliki wideo
* `StoredThumbnailsPath` - przetrzymywane miniaturki wideo
* `FFMPEGExecutablePath` - binarki programu FFMPEG
