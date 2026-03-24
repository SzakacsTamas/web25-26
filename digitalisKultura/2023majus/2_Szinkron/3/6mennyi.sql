SELECT film.eredeti, film.cim, COUNT(szinkron.szinkid)
FROM film, szinkron
WHERE film.filmaz = szinkron.filmaz
GROUP BY film.eredeti