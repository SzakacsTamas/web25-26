SELECT DISTINCT jatekos.nev
FROM bajnok, egyesulet, jatekos
WHERE bajnok.jatekos_id=jatekos.id AND
bajnok.egyesulet_id =egyesulet.id AND
egyesulet.nev = "MTK"
ORDER BY jatekos.neme, jatekos.nev