SELECT film.cim, film.eredeti, szinkron.szinesz, szinkron.szerep
FROM film, szinkron
WHERE szinkron.filmaz = film.filmaz AND szinkron.hang = "Anger Zsolt"