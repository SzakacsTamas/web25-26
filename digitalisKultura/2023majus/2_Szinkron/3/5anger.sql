SELECT film.cim, film.eredeti, szinkron.szinesz, szinkron.szerep
FROM film, szinkron
WHERE film.filmaz = szinkron.filmaz AND szinkron.hang = "Anger Zsolt"