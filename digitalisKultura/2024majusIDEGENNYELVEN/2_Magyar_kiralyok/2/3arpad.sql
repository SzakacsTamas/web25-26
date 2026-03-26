SELECT uralkodo.nev, hivatal.mettol, hivatal.meddig
FROM uralkodo, hivatal,uralkodohaz
WHERE uralkodo.azon=hivatal.uralkodo_az AND uralkodohaz.azon=uralkodo.uhaz_az AND uralkodohaz.nev = "Árpád-ház"
ORDER BY hivatal.mettol