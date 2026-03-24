SELECT DISTINCT film.magyarszoveg, film.cim
FROM film, szinkron
WHERE film.filmaz=szinkron.filmaz AND 
film.rendezo = "Christopher Nolan" AND film.studio = "Mafilm Audio Kft."
ORDER BY film.magyarszoveg