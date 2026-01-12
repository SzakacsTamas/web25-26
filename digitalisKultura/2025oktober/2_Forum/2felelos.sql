SELECT hirfolyam.megnevezes, felhasznalo.veznev, felhasznalo.utonev, felhasznalo.email
FROM hirfolyam, felhasznalo
WHERE hirfolyam.moderator = felhasznalo.id
