SELECT feladatsor.nevado, feladatsor.ag, SUM(feladat.pontszam) as maxPont
FROM feladatsor, feladat
WHERE feladatsor.id=feladat.feladatsorid
GROUP BY feladatsor.nevado
HAVING maxPont != 150