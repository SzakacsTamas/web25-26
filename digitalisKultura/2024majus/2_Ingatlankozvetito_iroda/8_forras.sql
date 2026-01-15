SELECT kozterulet, hazszam
FROM ingatlan
WHERE id NOT IN (SELECT ingatlan.id
FROM ingatlan, helyiseg
WHERE ingatlan.id=helyiseg.ingatlanid AND helyiseg.funkcio="konyha")
	AND id NOT IN (SELECT ingatlan.id
FROM ingatlan, helyiseg
WHERE ingatlan.id=helyiseg.ingatlanid AND helyiseg.funkcio="WC"
);
