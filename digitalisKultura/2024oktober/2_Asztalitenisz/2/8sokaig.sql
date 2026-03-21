SELECT jatekos.nev, MAX(bajnok.ev) - MIN(bajnok.ev) AS ido
FROM jatekos, bajnok
WHERE jatekos.id = bajnok.jatekos_id 
GROUP BY jatekos.nev
HAVING ido >= 10
ORDER BY ido DESC