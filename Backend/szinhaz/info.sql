

DROP TABLE IF EXISTS szekhely;
CREATE TABLE szekhely (id INT NOT NULL AUTO_INCREMENT , nev varchar(30) NOT NULL , `belfoldi` tinyint(1) NOT NULL, PRIMARY KEY (id) ) ENGINE = InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

INSERT INTO szekhely(nev,belfoldi) SELECT DISTINCT szekhely,belfoldi FROM szinhaz ORDER BY szekhely;
ALTER TABLE szinhaz ADD szekhely_id INT NOT NULL AFTER szekhely;
ALTER TABLE szinhaz ADD INDEX(szekhely_id);
UPDATE szinhaz SET szekhely_id=(SELECT szekhely_id FROM szekhely WHERE szekhely.nev=szinhaz.szekhely)
ALTER TABLE szinhaz DROP szekhely;


DROP TABLE IF EXISTS mufaj;
CREATE TABLE mufaj (id INT NOT NULL AUTO_INCREMENT , nev varchar(30) NOT NULL , PRIMARY KEY (id)) ENGINE = InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;
INSERT INTO mufaj(nev) SELECT DISTINCT mufaj FROM eloadas ORDER BY mufaj;
ALTER TABLE eloadas ADD mufaj_id INT NOT NULL AFTER datum;
ALTER TABLE eloadas ADD INDEX(mufaj_id);
UPDATE eloadas SET mufaj_id=(SELECT mufaj_id FROM mufaj WHERE mufaj.nev=eloadas.mufaj);
ALTER TABLE eloadas DROP mufaj;


DROP TABLE IF EXISTS nyelv;
CREATE TABLE nyelv (id INT NOT NULL AUTO_INCREMENT , nev varchar(15) NOT NULL , PRIMARY KEY (id)) ENGINE = InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;
INSERT INTO nyelv(nev) SELECT DISTINCT nyelv FROM eloadas ORDER BY nyelv;
ALTER TABLE eloadas ADD nyelv_id INT NOT NULL AFTER nyelv;
ALTER TABLE eloadas ADD INDEX(nyelv_id);
UPDATE eloadas SET nyelv_id=(SELECT nyelv_id FROM nyelv WHERE nyelv.nev=eloadas.nyelv);
ALTER TABLE eloadas DROP nyelv;

DROP TABLE IF EXISTS tulajdonsagnev;
CREATE TABLE tulajdonsagnev (id INT NOT NULL AUTO_INCREMENT , nev varchar(15) NOT NULL , PRIMARY KEY (id)) ENGINE = InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;
INSERT INTO tulajdonsagnev(nev) SELECT DISTINCT tulajdonsagnev FROM tulajdonsag ORDER BY tulajdonsagnev;
ALTER TABLE tulajdonsag ADD tulajdonsagnev_id INT NOT NULL AFTER tulajdonsagnev;
ALTER TABLE tulajdonsag ADD INDEX(tulajdonsagnev_id);
UPDATE tulajdonsag SET tulajdonsagnev_id=(SELECT tulajdonsagnev_id FROM tulajdonsagnev WHERE tulajdonsagnev.nev=tulajdonsag.tulajdonsagnev);
ALTER TABLE tulajdonsag DROP tulajdonsagnev;

ALTER TABLE szinhaz
DROP CONSTRAINT IF EXISTS szekhely_fk;
ALTER TABLE szinhaz
  ADD CONSTRAINT szekhely_fk FOREIGN KEY (szekhely_id) REFERENCES szekhely (id) in delete set null;


ALTER TABLE eloadas
DROP CONSTRAINT mufaj_fk;
drop constraint nyelv_fk,
ALTER TABLE eloadas
  ADD CONSTRAINT mufaj_fk FOREIGN KEY (mufaj_id) REFERENCES mufaj (id) in delete set null;
  ADD CONSTRAINT nyelv_fk, FOREIGN KEY (nyelv_id) REFERENCES nyelv (id) in delete set null;

ALTER TABLE tulajdonsag
DROP CONSTRAINT IF EXISTS tulajdonsagnev_fk;
ALTER TABLE tulajdonsag
  ADD CONSTRAINT tulajdonsagnev_fk FOREIGN KEY (tulajdonsagnev_id) REFERENCES tulajdonsagnev (id) in delete set null;
