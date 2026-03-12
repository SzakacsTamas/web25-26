SELECT feladatsor.nevado
FROM feladatsor
WHERE feladatsor.nevado LIKE "% %" AND  feladatsor.nevado NOT LIKE "% % %"