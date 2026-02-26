SELECT bajnok.ev
FROM bajnok, versenyszam
WHERE versenyszam.nev = "vegyes páros" AND
bajnok.vsz_id = versenyszam.id
ORDER BY bajnok.ev
LIMIT 1;