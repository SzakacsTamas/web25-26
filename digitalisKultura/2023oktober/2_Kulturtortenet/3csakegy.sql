SELECT feladatsor.nevado
FROM feladatsor
WHERE feladatsor.nevado NOT LIKE "% % %" AND feladatsor.nevado LIKE "% %";