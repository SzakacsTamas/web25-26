SELECT feladatsor.nevado, feladatsor.ag, SUM(feladat.pontszam) AS maxPontszam
FROM feladatsor, feladat
WHERE feladatsor.id=feladat.feladatsorid
GROUP BY feladatsor.nevado
HAVING maxPontszam <> 150