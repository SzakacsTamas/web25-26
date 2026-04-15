SELECT feladatsor.nevado, COUNT(megoldas.pontszam)
FROM feladatsor, csapat, feladat, megoldas
WHERE csapat.id=megoldas.csapatid AND megoldas.feladatid =feladat.id AND
feladatsor.id=feladat.feladatsorid AND csapat.nev = "#win" AND megoldas.pontszam = 0 
GROUP BY feladatsor.nevado