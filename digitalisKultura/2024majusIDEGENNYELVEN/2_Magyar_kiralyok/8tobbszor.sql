SELECT uralkodo.nev, Sum(meddig-mettol+1) 
FROM uralkodo, hivatal
WHERE uralkodo.azon=hivatal.uralkodo_az
GROUP BY uralkodo.nev
HAVING COUNT(uralkodo.azon) > 1
