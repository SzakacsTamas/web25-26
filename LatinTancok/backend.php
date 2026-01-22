<?php
session_start();
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $json = file_get_contents("php://input");
    $data = json_decode($json, true);
    if (isset($_FILES["file"]) && $_FILES["file"]["name"] === "tancrend.txt") {
        $fajlNev = $_FILES["file"]["tmp_name"];
        $betoltottFajl = fopen($fajlNev, "r");
        $szam = 0;
        $tomb = [];

        while (!feof($betoltottFajl)) {
            $sor = trim(fgets($betoltottFajl));

            $tomb[] = $sor;
            $szam++;

            if ($szam % 3 == 0) {
                $osszesTanc[] = [
                    "tanc" => $tomb[0],
                    "lany" => $tomb[1],
                    "fiu" => $tomb[2],
                ];
                $tomb = [];
            }
        }
        $_SESSION["adatok"] = $osszesTanc;
        fclose($betoltottFajl);
        $adatok = [];
        $tancok = [];
        $lanyok = [];
        $fiuk = [];
        foreach ($_SESSION["adatok"] as $elem) {
            if (!in_array($elem["tanc"], $tancok)) {
                $tancok[] = $elem["tanc"];
            }
        }

        foreach ($_SESSION["adatok"] as $elem) {
            if (!in_array($elem["lany"], $lanyok)) {
                $lanyok[] = $elem["lany"];
            }
            
            if (!in_array($elem["fiu"], $fiuk)) {
                $fiuk[] = $elem["fiu"];
            }
        }
        $adatok[] = $tancok;
        $adatok[] = $lanyok;
        $adatok[] = $fiuk;
        $json = json_encode($adatok);
        echo $json;
    }
    elseif ($data["feladat"] == "2") {
        $megoldas = [
            "elsoTanc" => $_SESSION["adatok"][0]["tanc"],
            "utolsoTanc" => end($_SESSION["adatok"])["tanc"],
        ];
        $json = json_encode($megoldas);
        echo $json;
    }
    elseif ($data["feladat"] == "3" && isset($data["tanc"])) {
        $megoldas = 0;
        foreach ($_SESSION["adatok"] as $elem) {
            if ($elem["tanc"] == $data["tanc"]) {
                $megoldas++;
            }
        }
        $json = json_encode($megoldas);
        echo $json;
    } 

    elseif ($data["feladat"] == "4") {
        $megoldas = [];
        
        foreach ($_SESSION["adatok"] as $elem) {
            if (($elem["lany"] == $data["tancos"] || $elem["fiu"] == $data["tancos"])&&
                !in_array($elem["tanc"], $megoldas)) {
                $megoldas[] = $elem["tanc"];
            }
 
        }
     
      
        $json = json_encode($megoldas);
        echo $json;
    }
elseif ($data["feladat"] == "5") {
        $megoldas = "";
        foreach ($_SESSION["adatok"] as $elem) {
            if ($elem["tanc"] == $data["tanc"]) {
                if ($elem["lany"] == $data["tancos"]) {
                    $megoldas = $elem["fiu"];
                }
                if ($elem["fiu"] == $data["tancos"]) {
                    $megoldas = $elem["lany"];
                }
            }
        }
        $json = json_encode($megoldas);
        echo $json;
    }
  
 elseif ($data["feladat"] == "6") {
        $fiuk = [];
        $lanyok = [];
        foreach ($_SESSION["adatok"] as $elem) {
            if (isset($fiuk[$elem["fiu"]])) {
                $fiuk[$elem["fiu"]] = $fiuk[$elem["fiu"]] + 1;
            } else {
                $fiuk[$elem["fiu"]] = 1;
            }

            if (isset($lanyok[$elem["lany"]])) {
                $lanyok[$elem["lany"]] = $lanyok[$elem["lany"]] + 1;
            } else {
                $lanyok[$elem["lany"]] = 1;
            }
        }
    
        $megoldas[] = array_keys($fiuk, max($fiuk));
        $megoldas[] = array_keys($lanyok, max($lanyok));
        $json = json_encode($megoldas);
        echo $json;
    }

    elseif ($data["feladat"] == "7") {
        $megoldas = [];
        foreach ($_SESSION["adatok"] as $elem) {
            if (isset($megoldas[$elem["tanc"]])) {
                $megoldas[$elem["tanc"]] = $megoldas[$elem["tanc"]] + 1;
            } else {
                $megoldas[$elem["tanc"]] = 1;
            }
        }
        $legtobbTanc = array_keys($megoldas, max($megoldas))[0];
                $json = json_encode($legtobbTanc);
        echo $json;
    }
} 