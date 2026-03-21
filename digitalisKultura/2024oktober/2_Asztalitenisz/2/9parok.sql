SELECT DISTINCT jatekos.nev
FROM jatekos, bajnok, versenyszam
WHERE jatekos.id=bajnok.jatekos_id AND
versenyszam.id=bajnok.vsz_id AND
 versenyszam.nev="vegyes páros" AND
jatekos.neme=1 AND
bajnok.ev IN (SELECT bajnok.ev FROM jatekos, bajnok,versenyszam
                    WHERE jatekos.id=bajnok.jatekos_id AND versenyszam.id = bajnok.vsz_id AND versenyszam.nev = "vegyes páros" AND jatekos.nev = "Pergel Szandra")