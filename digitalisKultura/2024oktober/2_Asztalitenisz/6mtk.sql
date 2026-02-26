SELECT DISTINCT jatekos.nev
FROM egyesulet, jatekos, bajnok
WHERE egyesulet.nev = "MTK" AND
egyesulet.id=bajnok.egyesulet_id AND bajnok.jatekos_id = jatekos.id
ORDER BY jatekos.neme, jatekos.nev;