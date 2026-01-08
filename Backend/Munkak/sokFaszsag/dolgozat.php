<?php
session_start();

function felhasznalokListazasa() {
    $szoveg = "<ul>";
    foreach ($_SESSION["felhasznalok"] as $nev => $adatok) {
        $szoveg .= "<li>Név: $nev - Jelszó: {$adatok[0]} - Admin: {$adatok[1]}</li>";
    }
    $szoveg .= "</ul>";
    return $szoveg;
}


if (!isset($_SESSION["belepve"])) $_SESSION["belepve"] = false;
if (!isset($_SESSION["admin"])) $_SESSION["admin"] = false;
if (!isset($_SESSION["nev"])) $_SESSION["nev"] = "";
if (!isset($_SESSION["felhasznalok"])) $_SESSION["felhasznalok"] = [];
if (!isset($_SESSION["userekHtml"])) $_SESSION["userekHtml"] = "";
if (!isset($_SESSION["simaFelhasznalo"])) $_SESSION["simaFelhasznalo"] = false;


if ($_SERVER["REQUEST_METHOD"] == "GET") {
    
 
    if (isset($_GET["kilepes"])) {
        $_SESSION["belepve"] = false;
        $_SESSION["admin"] = false;
        $_SESSION["nev"] = "";
        $_SESSION["simaFelhasznalo"] = false;
    }

    if (isset($_GET["nev"]) && isset($_GET["jelszo"])) {
        $nev = $_GET["nev"];
        $jelszo = $_GET["jelszo"];

        if ($nev == "admin" && $jelszo == "admin") {
            $_SESSION["belepve"] = true;
            $_SESSION["admin"] = true;
            $_SESSION["nev"] = "admin";
            $_SESSION["userekHtml"] = felhasznalokListazasa();
        } elseif (isset($_SESSION["felhasznalok"][$nev])) {
            if ($_SESSION["felhasznalok"][$nev][0] == $jelszo) {
                $_SESSION["belepve"] = true;
                $_SESSION["nev"] = $nev;

                if ($_SESSION["felhasznalok"][$nev][1] == "true") {
                    $_SESSION["admin"] = true;
                    $_SESSION["userekHtml"] = felhasznalokListazasa();
                } else {
                    $_SESSION["simaFelhasznalo"] = true;
                }
            }
        }
    }


    if (isset($_GET["ujnev"]) && isset($_GET["ujjelszo"]) && isset($_GET["jog"])) {
        $ujnev = $_GET["ujnev"];
        $ujjelszo = $_GET["ujjelszo"];
        $jog = $_GET["jog"]; 

        $_SESSION["felhasznalok"][$ujnev] = [$ujjelszo, $jog];
        $_SESSION["userekHtml"] = felhasznalokListazasa();
    }

  
    if (isset($_GET["torol"])) {
        $kit = $_GET["torol"];
        if (isset($_SESSION["felhasznalok"][$kit])) {
            unset($_SESSION["felhasznalok"][$kit]);
            $_SESSION["userekHtml"] = felhasznalokListazasa();
        }
    }
}
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <title>Dolgozat</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        #doboz {
            border: 2px solid black;
            margin: 20px auto;
            padding: 20px;
            max-width: 400px;
            text-align: center;
        }
    </style>
</head>
<body>

<div class="container">

    <?php if (!$_SESSION["belepve"]): ?>
      
        <div id="doboz">
            <h2>Bejelentkezés</h2>
            <form method="get" action="">
                <div class="mb-2">
                    <label>Felhasználónév:</label>
                    <input type="text" name="nev" class="form-control" required>
                </div>
                <div class="mb-2">
                    <label>Jelszó:</label>
                    <input type="password" name="jelszo" class="form-control" required>
                </div>
                <input type="submit" value="Belépés" class="btn btn-primary">
            </form>
        </div>

    <?php elseif ($_SESSION["admin"]): ?>
      
        <h2>Bejelentkezve: <?= $_SESSION["nev"] ?> (admin)</h2>

        <form method="get" action="">
            <input type="submit" name="kilepes" value="Kilépés" class="btn btn-danger">
        </form>

        <hr>
        <h3>Új felhasználó hozzáadása</h3>
        <form method="get" action="">
            <input type="text" name="ujnev" placeholder="Felhasználónév" class="form-control mb-2" required>
            <input type="password" name="ujjelszo" placeholder="Jelszó" class="form-control mb-2" required>
            
            <input type="hidden" name="jog" value="false"> 
            <label><input type="checkbox" name="jog" value="true"> Admin jog</label>
            <input type="submit" value="Hozzáadás" class="btn btn-success">
        </form>

        <hr>
        <h3>Felhasználók listája</h3>
        <?= $_SESSION["userekHtml"] ?>

        <form method="get" action="">
            <input type="text" name="torol" placeholder="Törlendő felhasználó neve" class="form-control mb-2" required>
            <input type="submit" value="Törlés" class="btn btn-danger">
        </form>

    <?php elseif ($_SESSION["simaFelhasznalo"]): ?>
      
        <h2>Üdv, <?= $_SESSION["nev"] ?>!</h2>
        <p>Örülünk, hogy itt vagy!</p>
        <form method="get" action="">
            <input type="submit" name="kilepes" value="Kilépés" class="btn btn-secondary">
        </form>
    <?php endif; ?>

</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
