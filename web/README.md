# Parkirna mjesta

## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Ivan Ercegovac | iercegova@foi.hr | 0016141703 | IvanErcegovac
Grgo Penava | gpenava@foi.hr | 0016142422 | GrgoPenava
David Milanović | dmilanovi@foi.hr | 0016145536 | DavidMilanovic1
Noel Zagorščak | nzagorsca@foi.hr | 0016142903 | NoelZagorscak02000

## Opis domene
Cilj izrade ove aplikacije je prikazivanje zauzetosti parkirnih mjesta u gradu. Korištenjem ove aplikacije, korisnici mogu puno brže i lakše pronaći parking u gradu što je pogotovo korisno u slučaju nekog događaja (npr. Špancirfest). Osim događaja u gradu, također se uzima u obzir i meteorološke prilike te se algoritmima procjenjuje trenutačan broj slobodnih/zauzetih parkirnih mjesta. 

## Specifikacija projekta

Oznaka | Naziv | Kratki opis | Odgovorni član tima
-| -| -| -
F01 | Registracija | Korisnik se registrira kako bi mogao pratiti svoje prijašnje parkirne sesije | Noel Zagorščak
F02 | Login | Korisnik se prijavljuje sa podacima sa kojima se registrirao kako bi dobio ulogu registriranog korisnika. | Ivan Ercegovac
F03 | Korisničko sučelje | Korisničko sučelje je sigurno glavna softverska komponenta ovog projekta sa korisničkog gledišta. Naime, sučelje će se sastojati od nekoliko stranica . Prva stranica prikazuje glavnu funkcionalnost ove aplikacije, a to je prikaz parkirnih mjesta na karti. Korisnik se kursorom kreće po karti i vidi slobodna ili zauzeta mjesta. Odabirom parkirnog mjesta, otvara se dodatan izbornik u kojem su detaljnije informacije. Druga stranica unutar aplikacije jest statistika gdje su podaci o svim parkirnim mjestima ovisno o vremenu i meteorološkim podacima. Treća stranica sadrži algoritme traženja i predviđanja koji će grafički analizirati prikazanu statistiku i pokušati predvidjeti slobodna parkirna mjesta. | Noel Zagorščak
F04 | Statistika | Statistička analiza prema različitim parametrima. Administrator objavljuje statističke podatke za različite parkirne zone. Iz ovih podataka razvit će se detaljna analiza. | Grgo Penava
F05 | Analiza | Administrator pravi detaljnu analizu statističkih podataka, ovisno o meteorološkim podacima dostupnima u bazi podataka, ovisno o godišnjem dobu. Također moraju se uzeti u obzir i navike ljudi u gradu koji se analizira. Analiza se prikazuje grafovima različitih vrsta. | David Milanović
F06 | Algoritam traženja | U algoritam će biti uneseni parametri prema kojima će algoritam, kada uzme podatke iz baze podataka u obzir, moći prepoznati odstupanja od trenda. Odnosno korisnik će preko algoritma moći prepoznati uzrok tog odstupanja.  | Ivan Ercegovac
F07 | Algoritam predviđanja | Koristeći već unesene podatke za parkirna mjesta, uzimaju se ulice u kojima se nalaze te se koristeći podacima iz prošlosti predviđa koja je vjerojatnost da će ulica biti u potpunosti zauzeta, odnosno da će sva parkirna mjesta biti zauzeta. | Grgo Penava
F08 | Algoritam predviđanja slobodnog mjesta | Slično prethodnom algoritmu, ovaj algoritam predviđanja uzima podatke iz baze i izražava kolika je mogućnost da je neko parkirno mjesto trenutno slobodno, mogućnost je izražena u postotku. | David Milanović

## Tehnologije i oprema
Visual Studio Community 2022, draw.io, GitHub, GitHub Classroom, SQLite, Visual Paradigm, MS Word
