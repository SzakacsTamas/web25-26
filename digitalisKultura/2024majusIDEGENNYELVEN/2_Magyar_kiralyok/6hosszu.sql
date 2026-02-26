 SELECT uralkodo.nev, (hivatal.meddig+1)-hivatal.mettol as uralkodasev
FROM uralkodo, hivatal
WHERE uralkodo.azon =hivatal.uralkodo_az
ORDER by uralkodasev DESC
LIMIT 1;