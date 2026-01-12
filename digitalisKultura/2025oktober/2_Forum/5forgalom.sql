SELECT hirfolyam.megnevezes, COUNT(uzenet.id)
FROM hirfolyam, uzenet
WHERE uzenet.h_id =hirfolyam.id
GROUP BY hirfolyam.id
ORDER BY uzenet.id DESC