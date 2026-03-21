SELECT bajnok.ev
FROM bajnok, versenyszam
WHERE bajnok.vsz_id=versenyszam.id AND
versenyszam.nev = "vegyes páros"
ORDER BY bajnok.ev 
LIMIT 1