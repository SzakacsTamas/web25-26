SELECT szinkron.szinesz, szinkron.hang, COUNT(szinkron.szinkid) AS filmekSzama
FROM szinkron
GROUP BY szinkron.szinesz, szinkron.hang
HAVING COUNT(szinkron.szinkid) >= 3 
ORDER BY filmekSzama DESC;