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
**Cel:** Dodać oraz obejrzeć swój nowo dodany film<br>
**Główny scenariusz:**
1. Zalogowany użytkownik przechodzi na podstronę, która umożliwia wrzucenie filmu wideo
2. Użytkownik wypełnia formularz dotyczący informacji na temat jego filmu (kategoria, tytuł, opis) oraz dodaje swój plik wideo
3. Aplikacja waliduje wprowadzone dane przez użytkownika
4. Aplikacja waliduje plik wideo wprowadzony przez użytkownika
5. Aplikacja generuje miniaturkę filmu
6. Aplikacja zapisuje dane na serwerze oraz w bazie danych
7. Aplikacja przekierowywuje użytkownika na podstronę z jego nowym filmem
8. Użytkownik odtwarza film w celu weryfikacji czy aplikacja wykonała zadanie poprawnie
**Rozszerzenia:**
2.1 Użytkownik podał za długi tytuł filmu
a) Aplikacja zwróciła błąd i poprosiła użytkownika stosownym komunikatem o zmniejszenie długości znaków w tytule
b) Użytkownik poprawił błąd i wysłał formularz ponownie
2.2 Użytkownik wysłał plik wideo w nieobsługiwanym formacie
a) Aplikacja zwróciła błąd o nieobsługiwanym formacie pliku dla wideo
b) Użytkownik wybiera poprawny plik wideo
2.3 Użytkownik wysłał za duży plik wideo
a) Aplikacja zwróciła błąd o zbyt dużym pliku wideo
b) Użytkownik zmontował film, by trwał on krócej i wrzuca plik ponownie

### Nazwa: Oddaj głos na film
**Inicjator:** Użytkownik<br>
**Cel:** Oddać głos na wybrany film<br>
**Główny scenariusz:**
1. Użytkownik przechodzi na podstronę z wybranym filmem
2. Użytkownik decyduje czy dany film mu się spodobał czy też nie
3. Użytkownik klika w wybraną przez siebie opcję
4. Aplikacja wysyła żądanie do serwera i aktualizuje statystyki
5. Aplikacja zwraca komunikat o poprawnym oddaniu głosu
**Rozszerzenia:**
3.1 Niezalogowany użytkownik wybrał opcję w głosowaniu
a) Aplikacja zwróciła błąd i poprosiła użytkownika o zalogowanie się
b) Użytkownik loguje się i ponownie oddaje głos
c) Aplikacja odnotowała głos i zaktualizowała statystyki

### Nazwa: Wyszukaj film
**Inicjator:** Użytkownik<br>
**Cel:** Wyszukac swój ulubiony film
**Główny scenariusz:**
1. Użytkownik wpisuje w pole wyszukiwarki interesującą go frazę
2. Aplikacja wyszukuje w bazie danych filmów, które pasują do podanego kryterium
3. Aplikacja przekierowywuje użytkownika na podstronę z wynikami
**Rozszerzenia:**
1.1 Użytkownik podaje pustą frazę do pola wyszukiwarki
a) Wyszukiwarka nie zadziała bez wpisania frazy
b) Użytkownik uzupełnia frazę w polu wyszukiwarki i wysyła formularz jeszcze raz
2.1 Aplikacja nie znajduje w bazie danych żadnych wideo na podstawie podanych kryteriów
a) Aplikacja przekierowywuje użytkownika na podstronę z wynikami ze stosownym komunikatem
b) Użytkownik zmienia frazę
c) Aplikacja ponownie wyszukuje dostępne wideo
d) Aplikacja przekierowywuje użytkownika na podstronę z wynikami
