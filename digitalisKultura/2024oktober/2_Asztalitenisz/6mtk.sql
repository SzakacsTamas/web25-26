SELECT DISTINCT jatekos.nev
FROM jatekos, egyesulet, bajnok
WHERE egyesulet.id = egyesulet_id
 AND jatekos.id = jatekos_id
 AND egyesulet.nev="MTK"
ORDER BY neme, jatekos.nev;
