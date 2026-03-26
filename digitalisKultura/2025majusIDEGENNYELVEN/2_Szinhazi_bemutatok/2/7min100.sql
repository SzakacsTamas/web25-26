SELECT szinhaz.nev, COUNT(eloadas.szinhazid) as szam
FROM szinhaz, eloadas
WHERE szinhaz.id = eloadas.szinhazid
GROUP BY szinhaz.nev
HAVING szam >= 100