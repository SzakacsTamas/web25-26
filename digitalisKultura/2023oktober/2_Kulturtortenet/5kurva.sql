SELECT csapat.nev, SUM(megoldas.pontszam) AS szam
FROM csapat, megoldas
WHERE csapat.id= megoldas.csapatid
GROUP BY csapat.id
ORDER BY szam DESC
