SELECT szinhaz.nev, eloadas.datum, eloadas.mufaj
FROM szinhaz, eloadas
WHERE szinhaz.id = eloadas.szinhazid AND eloadas.cim = "A kis herceg"
ORDER BY eloadas.datum