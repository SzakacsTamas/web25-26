SELECT aerob.letszam
FROM megye, aerob, allapot
WHERE megye.nev= "Zala" AND aerob.nem = 1 AND megye.kod = aerob.mkod AND aerob.allkod= allapot.kod AND allapot.nev = "egészséges"
