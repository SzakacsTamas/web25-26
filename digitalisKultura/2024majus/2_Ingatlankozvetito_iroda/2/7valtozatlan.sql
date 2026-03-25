SELECT ingatlan.kozterulet, ingatlan.hazszam, eladva.ar
FROM ingatlan, hirdetes AS hirdet, hirdetes AS eladva
WHERE ingatlan.id= hirdet.ingatlanid AND
ingatlan.id = eladva.ingatlanid AND 
hirdet.allapot = "meghirdetve" AND 
eladva.allapot = "eladva" AND 
eladva.ar = hirdet.ar 