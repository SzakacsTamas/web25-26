SELECT felhasznalo.veznev, felhasznalo.utonev
FROM felhasznalo
GROUP BY felhasznalo.veznev
HAVING COUNT(felhasznalo.veznev) > 1
ORDER BY felhasznalo.veznev, felhasznalo.utonev