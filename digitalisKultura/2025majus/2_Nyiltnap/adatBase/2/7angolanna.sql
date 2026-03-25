SELECT diakok.nev, diakok.email, diakok.telefon
FROM diakok, orak,kapcsolo
WHERE diakok.id = kapcsolo.diakid AND
kapcsolo.oraid=orak.id AND
orak.datum = "2028.11-10" AND 
orak.tanar = "Angol Anna"