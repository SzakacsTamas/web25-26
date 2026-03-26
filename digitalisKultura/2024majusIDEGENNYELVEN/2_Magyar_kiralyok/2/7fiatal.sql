SELECT nev, hivatal.mettol-uralkodo.szul as kezdoUr
FROM uralkodo, hivatal
WHERE uralkodo.azon = hivatal.uralkodo_az
GROUP BY uralkodo.azon
HAVING kezdoUr < 15
ORDER BY kezdoUr 