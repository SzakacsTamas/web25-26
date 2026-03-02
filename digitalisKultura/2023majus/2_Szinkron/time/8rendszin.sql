SELECT DISTINCT film.rendezo AS "Színész-rendező"
FROM film, szinkron
WHERE szinkron.filmaz=film.filmaz
AND film.rendezo=szinkron.szinesz
