SELECT aerob.letszam
FROM allapot, aerob, megye
WHERE aerob.nem = 1 AND allapot.kod = aerob.allkod AND allapot.nev = "egészséges" AND megye.nev = "Zala" AND megye.kod = aerob.mkod