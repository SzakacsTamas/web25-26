SELECT ingatlan.hazszam, hirdetes.ar
FROM hirdetes, ingatlan
WHERE hirdetes.ingatlanid=ingatlan.id AND ingatlan.kozterulet  = "Agyagos utca"