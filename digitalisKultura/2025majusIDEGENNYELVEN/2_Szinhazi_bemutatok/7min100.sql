SELECT szinhaz.nev, COUNT(eloadas.id)
FROM szinhaz, eloadas

WHERE szinhaz.id=eloadas.szinhazid
GROUP BY eloadas.szinhazid
HAVING COUNT(eloadas.id)>=100; 