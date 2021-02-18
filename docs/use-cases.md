# Use cases

### Nazwa: Załóż konto w aplikacji
**Inicjator:** Użytkownik<br>
**Cel:** Zalogować się na swoje nowo utworzone konto<br>
**Główny scenariusz:**
1. Użytkownik wchodzi na podstronę z formularzem rejestracji
2. Wypełnia dane dotyczące swojego nowego konta (email oraz hasło)
3. Aplikacja wysyła użytkownikowi link do aktywacji konta na jego skrzynke pocztową
4. Użytkownik aktywuje swoje konto poprzez link
5. Użytkownik przechodzi na podstronę z formularzem logowania
6. Użytkownik wypełnia dane formularza (email oraz hasło)
7. Aplikacja wyszukuje użytkownika w bazie danych 
8. Aplikacja sprawdza czy wszystkie dane formularza są prawidłowe
9. Aplikacja przekierowywuje użytkownika na stronę główną z komunikatem o poprawnym logowaniu
**Rozszerzenia:**
2.1 Użytkownik podał błędne dane
a) Aplikacja informuje użytkownika o błędzie i prosi go o wypełnienie formularza jeszcze raz
b) Użytkownik uzupełnia formularz poprawnymi danymi i wysyła jeszcze raz
6.1 Użytkownik wypełnia formularz logowania błędnymi danymi
a) Aplikacja informuje użytkownika o błędzie i prosi go o wypełnienie formularza jeszcze raz
b) Użytkownik klika w odnośnik "przypomnij hasło"
c) Użytkownik wypełnia formularz
d) Aplikacja wysyła użytkownikowi link do przypomnienia hasła
e) Użytkownik wprowadza nowe hasło
f) Użytkownik loguje się na swoje konto poprawnymi danymi

### Nazwa: Dodaj swój nowy film
**Inicjator:** Użytkownik<br>
**Cel:** Dodać oraz obejrzeć swój nowo dodany film
**Główny scenariusz:**
1. Zalogowany użytkownik przechodzi na podstronę, która umożliwia wrzucenie filmu wideo
2. Użytkownik wypełnia formularz dotyczący informacji na temat jego filmu (kategoria, tytuł, opis) oraz dodaje swój plik wideo.
3. Aplikacja waliduje wprowadzone dane przez użytkownika
4. Aplikacja waliduje plik wideo wprowadzony przez użytkownika
5. Aplikacja generuje miniaturkę filmu
6. Aplikacja zapisuje dane na serwerze oraz w bazie danych
7. Aplikacja przekierowywuje użytkownika na podstronę z jego nowym filmem
8. Użytkownik odtwarza film w celu weryfikacji czy aplikacja wykonała zadanie poprawnie
**Rozszerzenia:**
2.1 Użytkownik podał za długi tytuł filmu
2.2 Aplikacja zwróciła błąd i poprosiła użytkownika stosownym komunikatem o zmniejszenie długości znaków w tytule
2.3 Użytkownik
