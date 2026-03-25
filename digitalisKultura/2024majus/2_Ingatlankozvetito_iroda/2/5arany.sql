SELECT MAX(dragabb.ar) / MIN(olcsobb.ar)
FROM hirdetes as dragabb, hirdetes as olcsobb
WHERE dragabb.allapot = "meghirdetve" AND olcsobb.allapot = "meghirdetve"