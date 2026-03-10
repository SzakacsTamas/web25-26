SELECT csapat.nev, SUM(megoldas.pontszam) AS osszesPontasz
FROM csapat, megoldas
WHERE csapat.id=megoldas.csapatid 
GROUP BY csapat.nev 
ORDER BY 2 DESC