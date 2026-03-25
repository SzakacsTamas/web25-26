SELECT orak.datum, orak.terem, orak.orasorszam
FROM orak 
WHERE orak.targy = "angol"
ORDER BY 1 DESC, 3 DESC
