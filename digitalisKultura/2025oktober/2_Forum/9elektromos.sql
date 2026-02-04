SELECT felhasznalo.veznev, felhasznalo.utonev, COUNT(uzenet.id)
FROM felhasznalo, uzenet, hirfolyam
WHERE hirfolyam.megnevezes = "e-bike" AND felhasznalo.id=uzenet.f_id AND uzenet.h_id=hirfolyam.id AND uzenet.kuldido BETWEEN "12:00:00" AND "16:00:00"
GROUP BY felhasznalo.veznev