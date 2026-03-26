SELECT COUNT(uralkodo.nev), uralkodohaz.nev
FROM uralkodo, uralkodohaz
WHERE uralkodohaz.azon=uralkodo.uhaz_az 
GROUP BY uralkodohaz.nev
ORDER BY 1 DESC