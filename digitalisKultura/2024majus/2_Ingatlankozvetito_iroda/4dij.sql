SELECT SUM(hirdetes.ar*0.015) AS bevetel
FROM hirdetes
WHERE hirdetes.datum LIKE "2021%" AND hirdetes.allapot = "eladva"