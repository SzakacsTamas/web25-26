SELECT ingatlan.kozterulet, ingatlan.hazszam, IF(helyiseg.funkcio = "terasz", SUM((helyiseg.hossz*helyiseg.szel) / 50), SUM(helyiseg.hossz*helyiseg.szel)) as alapTerulet
FROM helyiseg, ingatlan
WHERE ingatlan.id=helyiseg.ingatlanid
GROUP BY helyiseg.ingatlanid
HAVING alapTerulet > 180
