SELECT Count(uralkodo.azon) AS Királyok_száma
FROM uralkodo, hivatal
WHERE uralkodo.azon = hivatal.uralkodo_az AND
 mettol<=1700 AND meddig>=1601;