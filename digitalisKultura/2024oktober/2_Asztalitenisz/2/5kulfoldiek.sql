SELECT DISTINCT egyesulet.orszag
FROM egyesulet, bajnok
WHERE bajnok.egyesulet_id=egyesulet.id AND
bajnok.ev > "2000" AND egyesulet.orszag != "Magyarország"
