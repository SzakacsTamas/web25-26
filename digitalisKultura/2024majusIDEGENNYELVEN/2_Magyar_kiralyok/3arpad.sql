SELECT uralkodo.nev, hivatal.mettol, hivatal.meddig
FROM uralkodo,uralkodohaz, hivatal
WHERE hivatal.uralkodo_az=uralkodo.azon AND uralkodohaz.azon=uralkodo.uhaz_az AND uralkodohaz.nev="Árpád-ház"
ORDER BY hivatal.meddig