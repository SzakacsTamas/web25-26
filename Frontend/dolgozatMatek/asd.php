<?php
include_once "szamKeres.php";
if (isset($_SERVER["PATH_INFO"])) {
    $apiParts = explode("/", $_SERVER["PATH_INFO"]);
    array_shift($apiParts);
    if ($_SERVER["REQUEST_METHOD"] == "GET") {
        switch ($apiParts[0]) {
            case "fakt":
                $szam = szamKeres($apiParts);
                if (count($szam) == 1 && count($szam) != 0 && $szam[0] <= 20) {
                    $megoldas = 1;
                    for ($i = 1; $i <= $szam[0]; $i++) {
                        $megoldas *= $i;
                    }
                    echo $megoldas;
                } else {
                    echo "Valami gond van a megadással!";
                }
                break;
            case "szorzat":
                $szam = szamKeres($apiParts);
                if (count($szam) >= 2 && count($szam) != 0) {
                    echo array_product($szam);
                } else {
                    echo "Valami gond van a megadással!";
                }
                break;
            case "haromszog":
                $szam = szamKeres($apiParts);
                if (count($szam) == 3 && count($szam) != 0) {
                    $s = array_sum($szam) / 2;
                    $terulet = sqrt($s * ($s - $szam[0]) * ($s - $szam[1]) * ($s - $szam[2]));
                    echo $terulet;
                } else {
                    echo "Valami gond van a megadással!";
                }
                break;
                /*
            case "random":
                $szam = szamKeres($apiParts);
                if (count($szam) == 1) {
                    echo rand(0, $szam[0]);
                } elseif (count($szam) == 2) {
                    echo rand($szam[0], $szam[1]);
                } elseif (count($szam) == 3) {
                    $random = rand($szam[0] / $szam[2], $szam[1] / $szam[2]) * $szam[2];
                    echo $random;
                } else {
                    echo "Valami gond van a megadással!";
                }
                break;
           */
            default:
                d($apiParts);
        }
    }
}
?>