SELECT megye.nev, SUM(aerob.letszam)
FROM megye, aerob, allapot
WHERE allapot.kod = aerob.allkod AND allapot.nev = "egészséges" AND aerob.mkod = megye.kod AND aerob.nem = 0
GROUP BY megye.nev
ORDER BY aerob.letszam DESC
