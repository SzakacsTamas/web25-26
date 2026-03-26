SELECT DISTINCT szinhaz.nev
FROM szinhaz, eloadas
WHERE szinhaz.szekhely = "szeged" AND eloadas.szinhazid =szinhaz.id AND eloadas.szinhazid NOT IN (SELECT eloadas.szinhazid FROM eloadas WHERE eloadas.mufaj = "Operett")