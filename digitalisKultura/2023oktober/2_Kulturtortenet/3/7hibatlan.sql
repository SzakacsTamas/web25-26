SELECT DISTINCT csapat.nev
FROM csapat, feladat, megoldas
WHERE csapat.id=megoldas.csapatid AND megoldas.feladatid=feladat.id AND feladat.pontszam = megoldas.pontszam