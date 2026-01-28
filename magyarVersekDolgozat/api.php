<?php

function versLe($adatBazis, $id)
{
    $leKer = $adatBazis->prepare("
        SELECT 
            v.id AS vers_id,
            v.cim,
            v.megjelenes_eve,
            k.nev AS kolto_nev,
            m.megnevezes AS mufaj,
            GROUP_CONCAT(vs.tartalom ORDER BY vs.sorszam SEPARATOR '\n') AS versszakok
        FROM versek v
        JOIN koltok k ON v.kolto_id = k.id
        LEFT JOIN mufajok m ON v.mufaj_id = m.id
        LEFT JOIN versszakok vs ON vs.vers_id = v.id
        WHERE v.id = ?
        GROUP BY v.id
    ");
    $leKer->execute([$id]);
    return $leKer->fetchAll(PDO::FETCH_ASSOC);
}

function versLeElsoVersszak($adatBazis, $id)
{
    $leKer = $adatBazis->prepare("
        SELECT 
            v.id AS vers_id,
            v.cim,
            v.megjelenes_eve,
            k.nev AS kolto_nev,
            m.megnevezes AS mufaj,
            vs.tartalom AS versszakok
        FROM versek v
        JOIN koltok k ON v.kolto_id = k.id
        LEFT JOIN mufajok m ON v.mufaj_id = m.id
        LEFT JOIN versszakok vs 
            ON vs.vers_id = v.id AND vs.sorszam = 1
        WHERE v.id = ?
    ");
    $leKer->execute([$id]);
    return $leKer->fetch(PDO::FETCH_ASSOC);
}


$adatBazis = new PDO(
    "mysql:host=localhost;dbname=magyar_irodalom;charset=utf8",
    "root",
    ""
);

$leKerHossz = $adatBazis->prepare("SELECT COUNT(*) FROM versek;");
$leKerHossz->execute();
$versHossz = $leKerHossz->fetchColumn();


if (isset($_SERVER["PATH_INFO"])) {
    $apiParts = explode("/", $_SERVER["PATH_INFO"]);
    array_shift($apiParts);

    if ($_SERVER["REQUEST_METHOD"] === "GET") {

        switch ($apiParts[0]) {

    
            case "versek":
                $adatok = [];

                $darab = isset($apiParts[1]) ? (int)$apiParts[1] : 1;

                for ($i = 0; $i < $darab; $i++) {
                    $randomId = rand(1, $versHossz);
                    $adatok[] = versLeElsoVersszak($adatBazis, $randomId);
                }

                echo json_encode($adatok);
                break;

 
            case "vers":
                echo json_encode(versLe($adatBazis, $apiParts[1]));
                break;

            case "kolto":

                if (count($apiParts) == 2) {
                    $leKer = $adatBazis->prepare("
                        SELECT 
                            k.id AS kolto_id,
                            k.nev,
                            k.szuletesi_datum,
                            k.szuletesi_hely,
                            k.halalozi_datum,
                            k.halalozi_hely,
                            k.eletrajz,
                            v.id AS vers_id,
                            v.cim,
                            v.megjelenes_eve,
                            m.megnevezes AS mufaj
                        FROM koltok k
                        LEFT JOIN versek v ON v.kolto_id = k.id
                        LEFT JOIN mufajok m ON v.mufaj_id = m.id
                        WHERE k.id = ?
                        ORDER BY v.id
                    ");
                    $leKer->execute([$apiParts[1]]);
                    $adatok = $leKer->fetchAll(PDO::FETCH_ASSOC);

                } else {
                    $leKer = $adatBazis->prepare("SELECT * FROM koltok;");
                    $leKer->execute();
                    $adatok = $leKer->fetchAll(PDO::FETCH_ASSOC);
                }

                echo json_encode($adatok);
                break;
        }
    }
}
