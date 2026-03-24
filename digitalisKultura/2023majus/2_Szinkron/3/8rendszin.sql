SELECT DISTINCT film.rendezo AS "Színész-rendező"
FROM film, szinkron
WHERE film.filmaz =szinkron.filmaz AND szinkron.szinesz=film.rendezo