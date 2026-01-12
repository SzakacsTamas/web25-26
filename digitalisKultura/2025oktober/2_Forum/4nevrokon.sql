SELECT felhasznalo.veznev, felhasznalo.utonev
FROM felhasznalo 
GROUP BY felhasznalo.veznev, felhasznalo.utonev
HAVING COUNT(*) > 1
ORDER BY veznev, utonev   