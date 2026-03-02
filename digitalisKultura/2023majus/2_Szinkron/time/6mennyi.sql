SELECT film.eredeti, film.cim, COUNT(szinkron.szinkid) AS szinkSzerepSzam
FROM film, szinkron
WHERE szinkron.filmaz=film.filmaz 
GROUP BY film.eredeti