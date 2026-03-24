SELECT SUM(aerob.letszam)
FROM aerob, megye
WHERE megye.kod=aerob.mkod AND megye.nev = "Somogy"