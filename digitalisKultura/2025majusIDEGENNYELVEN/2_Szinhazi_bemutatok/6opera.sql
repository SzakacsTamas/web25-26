SELECT AVG(tulajdonsag.ertek / 60)
FROM tulajdonsag, eloadas
WHERE tulajdonsag.nev="perc" AND tulajdonsag.eloadasid=eloadas.id
AND eloadas.mufaj="opera"