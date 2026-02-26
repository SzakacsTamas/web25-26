SELECT jatekos.nev, Max(ev) - Min(ev) AS idotav
FROM jatekos, bajnok
WHERE jatekos.id = bajnok.jatekos_id 
GROUP BY jatekos.id
HAVING idotav >= 10
ORDER BY idotav DESC
