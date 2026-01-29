<?php

function versLe($adatBazis, $id)
{
    $leKer = $adatBazis->prepare("SELECT 
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

$adatBazis = new PDO("mysql:host=localhost; dbname=magyar_irodalom;charset=utf8", "root", "");
$json = file_get_contents("php://input");
$data = json_decode($json, true);
$leKerHossz = $adatBazis->prepare("SELECT COUNT(*) FROM versek;");
$leKerHossz->execute();
$versHossz = $leKerHossz->fetchColumn();

if (isset($_SERVER["PATH_INFO"])) {
    $apiParts = explode("/", $_SERVER["PATH_INFO"]);
    array_shift($apiParts);
    if ($_SERVER["REQUEST_METHOD"] == "GET") {
        switch ($apiParts[0]) {
            case "versek":
                $adatok = [];
if (count($apiParts) == 2) {
    for ($i = 0; $i < $apiParts[1]; $i++) {
        $adatok[] = versLe($adatBazis, rand(1, $versHossz))[0]; 
    }
} elseif (count($apiParts) == 1) {
    $adatok = [versLe($adatBazis, rand(1, $versHossz))[0]]; 
}
                echo json_encode($adatok);
                break;
            case "vers":
                echo json_encode(versLe($adatBazis, $apiParts[1]));
                break;
            case "kolto":
                if (count($apiParts) == 2) {
                    $leKer = $adatBazis->prepare("SELECT 
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
                                                ORDER BY v.id;");
                    $leKer->execute([$apiParts[1]]);
                    $adatok = $leKer->fetchAll(PDO::FETCH_ASSOC);
                } elseif (count($apiParts) == 1) {
                    $leKer = $adatBazis->prepare("SELECT * from koltok;");
                    $leKer->execute();
                    $adatok = $leKer->fetchAll(PDO::FETCH_ASSOC);
                }
                echo json_encode($adatok);
                break;
            default:
        }
    }
}