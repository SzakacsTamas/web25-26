SELECT uralkodo.nev
FROM uralkodo, hivatal
WHERE hivatal.uralkodo_az=uralkodo.azon AND hivatal.koronazas > hivatal.mettol
