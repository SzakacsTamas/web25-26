SELECT feladatsor.nevado, feladatsor.kituzes, feladatsor.hatarido
FROM feladatsor
WHERE feladatsor.ag = "irodalom" AND MONTH(feladatsor.kituzes) = MONTH(feladatsor.hatarido)