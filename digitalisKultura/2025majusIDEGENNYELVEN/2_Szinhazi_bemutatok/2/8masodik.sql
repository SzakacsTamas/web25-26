SELECT szinhaz.szekhely, COUNT(*) as szam
FROM szinhaz
GROUP BY szinhaz.szekhely
ORDER BY szam DESC
LIMIT 1, 1