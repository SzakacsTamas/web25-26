SELECT feladatsor.nevado, feladatsor.ag, SUM(feladat.pontszam)
FROM feladatsor, feladat
WHERE feladatsor.id = feladatsorid
GROUP BY feladatsorid
HAVING SUM(pontszam) <> 150