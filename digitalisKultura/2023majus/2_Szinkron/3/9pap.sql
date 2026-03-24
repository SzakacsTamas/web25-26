SELECT szinkron.hang, film.cim
FROM szinkron, film
WHERE szinkron.filmaz = film.filmaz AND 
film.filmaz IN (SELECT film.filmaz FROM film, szinkron WHERE
film.filmaz = szinkron.filmaz AND szinkron.hang = "Pap Kati")
AND szinkron.hang != "Pap Kati"
ORDER BY film.cim, szinkron.hang