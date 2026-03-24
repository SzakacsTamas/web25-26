SELECT film.rendezo, film.szinkronrendezo
FROM film
WHERE film.ev > 2000
GROUP BY film.rendezo, film.szinkronrendezo