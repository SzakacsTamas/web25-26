SELECT orak.datum, orak.orasorszam, orak.targy, orak.tanar,
 orak.ferohely-Count(orak.id) AS szabad
FROM orak, kapcsolo
WHERE kapcsolo.oraid=orak.id
GROUP BY orak.id
HAVING szabad>0
ORDER BY szabad DESC; 