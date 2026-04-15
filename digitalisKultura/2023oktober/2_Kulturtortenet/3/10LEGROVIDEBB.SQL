SELECT feladatsor.nevado FROM feladatsor
ORDER BY Datediff(feladatsor.hatarido, feladatsor.kituzes)
LIMIT 1