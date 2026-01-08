<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "cukraszda";

$conn = mysqli_connect($servername, $username, $password, $dbname);



$apiParts = explode("/", $_GET["path"]);

if ($apiParts[0] == "feladat") {
    if ($_SERVER["REQUEST_METHOD"] == "GET") {
        $megoldas = ["info" => "success"];

        switch ($apiParts[1]) {
            case "1":
                $query = "SELECT id, kaloria FROM termek WHERE kaloria IS NULL;";
                $results = mysqli_query($conn, $query);

                $megoldas["feladat1"] = [];
                while ($row = mysqli_fetch_assoc($results)) {
                    $megoldas["feladat1"][] = $row;
                }
                echo json_encode($megoldas);
                break;

            case "2":
                $query = "SELECT nev, mennyiseg FROM termek INNER JOIN kiszereles ON termek.kiszerelesId = kiszereles.id WHERE mennyiseg LIKE '%g';";
                $results = mysqli_query($conn, $query);

                $megoldas["feladat2"] = [];
                while ($row = mysqli_fetch_assoc($results)) {
                    $megoldas["feladat2"][] = [
                        "nev" => $row["nev"],
                        "mennyiseg" => $row["mennyiseg"]
                    ];
                }
                echo json_encode($megoldas);
                break;

            case "4":
                $query = "SELECT allergen.nev, COUNT(*) AS termek_szam FROM allergen INNER JOIN allergeninfo ON allergeninfo.allergenId = allergen.id GROUP BY allergen.nev ORDER BY termek_szam DESC;";
                $results = mysqli_query($conn, $query);

                $megoldas["feladat4"] = [];
                while ($row = mysqli_fetch_assoc($results)) {
                    $megoldas["feladat4"][] = [
                        "allergen" => $row['nev'],
                        "termek_szam" => $row['termek_szam']
                    ];
                }
                echo json_encode($megoldas);
                break;
        }
    }
}

mysqli_close($conn);
?>
