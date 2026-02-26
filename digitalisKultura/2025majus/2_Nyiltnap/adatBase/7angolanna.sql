SELECT diakok.nev, diakok.email, diakok.telefon
FROM diakok, orak, kapcsolo
WHERE orak.id=kapcsolo.oraid AND kapcsolo.diakid=diakok.id AND orak.tanar= "Angol Anna" AND orak.datum ="2028.11-10";