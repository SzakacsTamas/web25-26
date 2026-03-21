SELECT bajnok.ev, versenyszam.nev
FROM bajnok, versenyszam, jatekos
WHERE bajnok.vsz_id=versenyszam.id AND jatekos.id=bajnok.jatekos_id AND jatekos.nev = "Harczi Zsolt" 