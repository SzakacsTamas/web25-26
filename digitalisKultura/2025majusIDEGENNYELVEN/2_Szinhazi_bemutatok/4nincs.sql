SELECT cim, datum
FROM eloadas
WHERE szinhazid IS NULL
 AND eloadas.datum LIKE "2017%"; 