SELECT uralkodo.nev, hivatal.meddig - hivatal.mettol +1
FROM uralkodo, hivatal
WHERE uralkodo.azon = hivatal.uralkodo_az 
GROUP BY uralkodo.nev
ORDER BY 2 DESC
LIMIT 1