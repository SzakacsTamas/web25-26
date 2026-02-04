SELECT szinkron.hang, film.cim
FROM szinkron, film
WHERE szinkron.filmaz=film.filmaz AND film.filmaz in (SELECT szinkron.filmaz
                                                     FROM szinkron
                                                     WHERE szinkron.hang= "Pap Kati")
                                                     AND szinkron.hang != "Pap Kati"
 ORDER BY film.cim, szinkron.hang