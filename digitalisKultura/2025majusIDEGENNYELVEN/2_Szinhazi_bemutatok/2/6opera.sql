SELECT AVG(tulajdonsag.ertek) / 60
FROM tulajdonsag, eloadas
WHERE tulajdonsag.eloadasid=eloadas.id AND 
eloadas.mufaj = "opera" AND tulajdonsag.nev = "perc"