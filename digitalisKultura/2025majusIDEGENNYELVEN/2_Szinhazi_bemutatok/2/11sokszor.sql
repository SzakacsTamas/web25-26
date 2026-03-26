SELECT szinhaz.szekhely, COUNT(*) szam
FROM szinhaz
GROUP BY szinhaz.szekhely
ORDER BY szam DESC
LIMIT 1