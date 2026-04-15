SELECT feladatsor.nevado, feladatsor.ag, SUM(feladat.pontszam) as pontszam
FROM feladatsor, feladat
WHERE feladatsor.id=feladat.feladatsorid
GROUP BY feladatsor.nevado
HAVING pontszam != 150