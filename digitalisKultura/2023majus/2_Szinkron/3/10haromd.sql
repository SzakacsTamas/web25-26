SELECT szinkron.szinesz, szinkron.hang, COUNT(*) AS legalabbHarom
FROM szinkron, film
WHERE szinkron.filmaz = film.filmaz 
GROUP BY szinkron.szinesz
HAVING legalabbHarom >= 3
ORDER BY legalabbHarom DESC