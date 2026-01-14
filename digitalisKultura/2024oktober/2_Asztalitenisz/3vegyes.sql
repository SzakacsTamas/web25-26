SELECT bajnok.ev 
FROM versenyszam, bajnok
WHERE versenyszam.nev="vegyes páros" AND vsz_id=versenyszam.id
ORDER BY bajnok.ev
LIMIT 1

