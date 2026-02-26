SELECT bajnok.ev, versenyszam.nev
FROM bajnok, versenyszam, jatekos
WHERE jatekos.nev = "Harczi Zsolt" AND 
jatekos.id =bajnok.jatekos_id AND
bajnok.vsz_id = versenyszam.id;