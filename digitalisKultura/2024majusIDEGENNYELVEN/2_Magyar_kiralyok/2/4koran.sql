SELECT uralkodo.nev
FROM uralkodo, hivatal
WHERE uralkodo.azon = hivatal.uralkodo_az AND hivatal.mettol < hivatal.koronazas