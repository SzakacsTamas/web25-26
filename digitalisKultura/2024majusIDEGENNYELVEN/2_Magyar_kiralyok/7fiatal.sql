SELECT uralkodo.nev, hivatal.mettol - uralkodo.szul+1 as eletkor
FROM uralkodo, hivatal
WHERE uralkodo.azon = hivatal.uralkodo_az AND 
(hivatal.mettol - uralkodo.szul+1) < 15
ORDER BY eletkor;