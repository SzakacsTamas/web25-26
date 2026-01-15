SELECT ingatlan.kozterulet, ingatlan.hazszam, hirdetes.datum
FROM ingatlan, hirdetes
WHERE ingatlan.id=hirdetes.ingatlanid 
GROUP BY ingatlan.id
HAVING COUNT(ingatlan.id)=1
ORDER BY datum ASC
LIMIT 1