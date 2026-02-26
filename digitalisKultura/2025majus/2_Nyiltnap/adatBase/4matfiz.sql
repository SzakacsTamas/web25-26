SELECT orak.csoport, orak.targy, orak.datum
FROM orak
WHERE orak.csoport LIKE "9%" AND orak.targy = "matematika" OR orak.targy = "fizika"
ORDER BY orak.targy;