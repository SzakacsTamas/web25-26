SELECT ingatlan.hazszam, hirdetes.ar
FROM ingatlan, hirdetes
WHERE ingatlan.id=hirdetes.ingatlanid AND ingatlan.kozterulet = "Agyagos utca" AND hirdetes.allapot = "meghirdetve"