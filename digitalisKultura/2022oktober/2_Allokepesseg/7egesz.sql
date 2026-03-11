SELECT megye.nev, aerob.letszam
FROM megye, aerob, allapot
WHERE megye.kod=aerob.mkod AND aerob.allkod=allapot.kod AND
aerob.nem = 0  AND allapot.nev = "egészséges"
ORDER BY 2 DESC