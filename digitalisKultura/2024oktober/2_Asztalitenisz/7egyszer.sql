SELECT jatekos.nev, ev, versenyszam.nev
FROM jatekos, bajnok, versenyszam
WHERE jatekos.id = jatekos_id AND versenyszam.id = vsz_id
GROUP BY jatekos.id
HAVING Count(jatekos.id)=1;