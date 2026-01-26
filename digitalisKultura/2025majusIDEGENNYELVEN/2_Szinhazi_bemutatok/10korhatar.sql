SELECT eloadas.cim, alsoErtek.ertek, felsoErtek.ertek
FROM eloadas, tulajdonsag AS alsoErtek, tulajdonsag AS felsoErtek, szinhaz
WHERE alsoErtek.nev = "tol"
AND szinhaz.id=szinhazid AND
felsoErtek.nev = "ig" AND
alsoErtek.eloadasid = eloadas.id AND
felsoErtek.eloadasid =eloadas.id AND
szinhaz.szekhely = "Miskolc"
