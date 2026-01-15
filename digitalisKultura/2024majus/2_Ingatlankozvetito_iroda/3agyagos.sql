SELECT ingatlan.hazszam, hirdetes.ar
FROM ingatlan, hirdetes
WHERE hirdetes.ingatlanid=ingatlan.id AND ingatlan.kozterulet="Agyagos utca"
