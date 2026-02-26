SELECT diakok.telepules, COUNT(diakok.id)
FROM diakok
GROUP BY diakok.telepules
ORDER BY 2 DESC;