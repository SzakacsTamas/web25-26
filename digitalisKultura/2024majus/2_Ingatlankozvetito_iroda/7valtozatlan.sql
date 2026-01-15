SELECT ingatlan.kozterulet, ingatlan.hazszam, h2.ar
FROM ingatlan, hirdetes, hirdetes AS h2
WHERE hirdetes.ingatlanid=ingatlan.id 
AND h2.ingatlanid=ingatlan.id 
AND h2.allapot='meghirdetve'
 AND hirdetes.allapot='eladva'
 AND hirdetes.ar=h2.ar