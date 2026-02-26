SELECT COUNT(uralkodo.azon)
FROM uralkodo, hivatal
WHERE hivatal.uralkodo_az=uralkodo.azon AND
hivatal.meddig >=1601 AND hivatal.mettol <=1700;

