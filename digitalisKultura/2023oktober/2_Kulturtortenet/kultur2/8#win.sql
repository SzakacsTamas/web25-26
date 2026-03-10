SELECT feladatsor.nevado, COUNT(feladat.id)
FROM feladatsor, feladat
WHERE feladatsor.id=feladat.feladatsorid AND
feladat.id NOT IN (SELECT megoldas.feladatid
              FROM megoldas, csapat
 WHERE csapat.id=csapatid
 AND nev="#win") 
 GROUP BY nevado;