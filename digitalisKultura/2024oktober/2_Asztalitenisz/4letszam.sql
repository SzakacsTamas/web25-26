SELECT Count(jatekos.neme), IF(neme=0,"no","férfi")
FROM jatekos
GROUP BY jatekos.neme