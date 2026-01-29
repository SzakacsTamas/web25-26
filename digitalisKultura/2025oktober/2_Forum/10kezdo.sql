SELECT MAX(uzenet.kuldido) AS UtolsoUzenetIdeje
FROM uzenet
WHERE uzenet.f_id=(
 SELECT uzenet.f_id
 FROM uzenet
 ORDER BY uzenet.kuldido
 LIMIT 1
 )

