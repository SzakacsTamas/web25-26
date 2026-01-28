<?php
header('Content-Type: application/json; charset=utf-8');

// Adatbázis kapcsolat
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "magyar_irodalom";

$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    http_response_code(500);
    echo json_encode(["error" => "Connection failed: " . $conn->connect_error]);
    exit();
}

// Segédfüggvény random versekhez
function getRandomVers($conn, $limit = 1) {
    $limit = intval($limit);
    $sql = "SELECT v.id, v.cim, v.megjelenes_eve, k.id AS kolto_id, k.nev AS kolto_nev, k.szuletesi_datum, k.szuletesi_hely, k.halalozi_datum, k.halalozi_hely, k.eletrajz
            FROM versek v
            JOIN koltok k ON v.kolto_id = k.id
            ORDER BY RAND()
            LIMIT $limit";
    $result = $conn->query($sql);
    $vers = [];
    while($row = $result->fetch_assoc()) {
        $versszakok = [];
        $sql2 = "SELECT sorszam, tartalom FROM versszakok WHERE vers_id=".$row['id']." ORDER BY sorszam ASC";
        $res2 = $conn->query($sql2);
        while($szak = $res2->fetch_assoc()) $versszakok[] = $szak;

        $row['versszakok'] = $versszakok;
        $vers[] = $row;
    }
    return $vers;
}

// Segédfüggvény adott vers ID-hez
function getVersById($conn, $id) {
    $id = intval($id);
    $sql = "SELECT v.id, v.cim, v.megjelenes_eve, k.id AS kolto_id, k.nev AS kolto_nev, k.szuletesi_datum, k.szuletesi_hely, k.halalozi_datum, k.halalozi_hely, k.eletrajz
            FROM versek v
            JOIN koltok k ON v.kolto_id = k.id
            WHERE v.id=$id";
    $result = $conn->query($sql);
    if($row = $result->fetch_assoc()) {
        $versszakok = [];
        $sql2 = "SELECT sorszam, tartalom FROM versszakok WHERE vers_id=".$row['id']." ORDER BY sorszam ASC";
        $res2 = $conn->query($sql2);
        while($szak = $res2->fetch_assoc()) $versszakok[] = $szak;
        $row['versszakok'] = $versszakok;
        return $row;
    }
    return null;
}

// Segédfüggvény költők listájához
function getAllKoltok($conn) {
    $sql = "SELECT * FROM koltok ORDER BY nev ASC";
    $result = $conn->query($sql);
    $koltok = [];
    while($row = $result->fetch_assoc()) $koltok[] = $row;
    return $koltok;
}

// Segédfüggvény adott költőhöz
function getKoltoById($conn, $id) {
    $id = intval($id);
    $sql = "SELECT * FROM koltok WHERE id=$id";
    $result = $conn->query($sql);
    if($row = $result->fetch_assoc()) {
        $sql2 = "SELECT id, cim, megjelenes_eve FROM versek WHERE kolto_id=$id ORDER BY megjelenes_eve ASC";
        $res2 = $conn->query($sql2);
        $versek = [];
        while($v = $res2->fetch_assoc()) $versek[] = $v;
        $row['versek'] = $versek;
        return $row;
    }
    return null;
}

// URL feldolgozás
$request = $_SERVER['REQUEST_URI'];
$script = $_SERVER['SCRIPT_NAME'];
$path = str_replace(dirname($script), '', $request);
$parts = array_values(array_filter(explode('/', $path)));

if(count($parts) == 0) {
    echo json_encode(["message"=>"API működik"]);
    exit();
}

switch($parts[0]) {
    case 'versek':
        if(isset($parts[1])) {
            echo json_encode(getRandomVers($conn, intval($parts[1])));
        } else {
            echo json_encode(getRandomVers($conn, 1));
        }
        break;
    case 'vers':
        if(isset($parts[1])) {
            $v = getVersById($conn, intval($parts[1]));
            if($v) echo json_encode($v);
            else { http_response_code(404); echo json_encode(["error"=>"Vers nem található"]); }
        } else {
            http_response_code(400);
            echo json_encode(["error"=>"Vers ID hiányzik"]);
        }
        break;
    case 'kolto':
        if(isset($parts[1])) {
            $k = getKoltoById($conn, intval($parts[1]));
            if($k) echo json_encode($k);
            else { http_response_code(404); echo json_encode(["error"=>"Költő nem található"]); }
        } else {
            echo json_encode(getAllKoltok($conn));
        }
        break;
    default:
        http_response_code(404);
        echo json_encode(["error"=>"Ismeretlen végpont"]);
}

$conn->close();
?>
