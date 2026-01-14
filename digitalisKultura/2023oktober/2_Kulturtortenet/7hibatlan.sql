SELECT DISTINCT nev
FROM csapat, megoldas, feladat
WHERE csapat.id=csapatid
 AND feladatid=feladat.id
 AND megoldas.pontszam=feladat.pontszam; 