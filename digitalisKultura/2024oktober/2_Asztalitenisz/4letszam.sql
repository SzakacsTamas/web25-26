SELECT COUNT(jatekos.neme), IF(jatekos.neme=0,"nő","férfi")
FROM jatekos
GROUP BY jatekos.neme;
