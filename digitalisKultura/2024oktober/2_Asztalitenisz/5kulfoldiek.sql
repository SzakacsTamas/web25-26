SELECT DISTINCT egyesulet.orszag
FROM egyesulet, bajnok
WHERE bajnok.ev > 2000 AND
bajnok.egyesulet_id = egyesulet.id
AND egyesulet.orszag != "Magyarország";