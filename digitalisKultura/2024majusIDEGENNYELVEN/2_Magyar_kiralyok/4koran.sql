SELECT uralkodo.nev
FROM uralkodo, hivatal
WHERE hivatal.koronazas> hivatal.mettol AND uralkodo.azon =hivatal.uralkodo_az;