SELECT SUM(aerob.letszam) / megye.letszam
FROM megye,aerob
WHERE megye.nev = "Pest" AND aerob.mkod = megye.kod 