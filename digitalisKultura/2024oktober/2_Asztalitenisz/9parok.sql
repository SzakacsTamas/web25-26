SELECT DISTINCT jatekos.nev
FROM jatekos, bajnok, versenyszam
WHERE jatekos.id = jatekos_id
 AND vsz_id = versenyszam.id
 AND neme=1 AND versenyszam.nev="vegyes páros"
 AND ev IN (SELECT ev
 FROM jatekos, bajnok, versenyszam
 WHERE jatekos.id = jatekos_id
 AND vsz_id = versenyszam.id
 AND versenyszam.nev="vegyes páros"
 AND jatekos.nev="Pergel Szandra"); 