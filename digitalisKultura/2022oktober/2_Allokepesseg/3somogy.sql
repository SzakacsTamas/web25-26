SELECT SUM(aerob.letszam) AS somogyMegyeResztvevok
FROM megye, aerob
WHERE aerob.mkod=megye.kod AND megye.nev= "Somogy"