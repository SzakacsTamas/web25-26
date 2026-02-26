SELECT uralkodo.nev, hivatal.mettol, hivatal.meddig
FROM uralkodo, hivatal, uralkodohaz
WHERE hivatal.uralkodo_az= uralkodo.azon AND uralkodo.uhaz_az =uralkodohaz.azon AND 
uralkodohaz.nev = "Árpád-ház"
ORDER BY hivatal.mettol;