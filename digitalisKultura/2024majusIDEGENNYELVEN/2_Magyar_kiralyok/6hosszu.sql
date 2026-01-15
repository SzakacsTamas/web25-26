SELECT uralkodo.nev, hivatal.meddig-hivatal.mettol+1 AS uralkodoEv
FROM hivatal, uralkodo
WHERE hivatal.uralkodo_az=uralkodo.azon
ORDER BY uralkodoEv DESC
LIMIT 1