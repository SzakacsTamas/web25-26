SELECT SUM(hirdetes.ar / 100) * 1.5 AS penz
FROM hirdetes
WHERE YEAR(hirdetes.datum) = 2021 AND hirdetes.allapot = "eladva"