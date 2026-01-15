SELECT ingatlan.kozterulet, ingatlan.hazszam, SUM(if(helyiseg.funkcio="terasz",helyiseg.szel*helyiseg.hossz*0.5,helyiseg.szel*helyiseg.hossz)) AS Terulet
FROM ingatlan, helyiseg
WHERE ingatlan.id=helyiseg.ingatlanid
GROUP BY ingatlan.id
HAVING Terulet > 180