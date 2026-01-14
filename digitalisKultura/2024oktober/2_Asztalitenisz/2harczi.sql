SELECT versenyszam.nev AS versenyszamNeve, bajnok.ev
FROM jatekos, versenyszam, bajnok
WHERE jatekos.id=bajnok.jatekos_id AND versenyszam.id=bajnok.vsz_id AND jatekos.nev="Harczi Zsolt"