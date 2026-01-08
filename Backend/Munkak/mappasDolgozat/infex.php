<?php
/*
    $target_dir = "kepek/";
    $config["kepek"]["kicsi"]["dir"] = $target_dir . "kicsi";
    $config["kepek"]["kicsi"]["width"] = 100;
    $config["kepek"]["kicsi"]["height"] = 100;

    $config["kepek"]["nagy"]["dir"] = $target_dir . "nagy";
    $config["kepek"]["nagy"]["width"] = 800;
    $config["kepek"]["nagy"]["height"] = 600;
*/
if (isset($_FILES["fileToUpload"])) {

    $fajl = $_FILES["fileToUpload"];
    $tmp = $fajl["tmp_name"];
    $nev = $fajl["name"];

    $ext = strtolower(pathinfo($nev, PATHINFO_EXTENSION));

    $tiltott = ["php", "html", "js"];
    if (in_array($ext, $tiltott)) {
        echo "Hiba: {$ext} fájl feltöltése nem engedélyezett!";
    } else {
        $check = getimagesize($tmp);

        if ($check !== false) {
            $kicsiMappa = "kepek/kicsi/";
            $nagyMappa = "kepek/nagy/";

            if (!is_dir($nagyMappa)) mkdir($nagyMappa, 0755, true);
            if (!is_dir($kicsiMappa)) mkdir($kicsiMappa, 0755, true);

            // NAGY
            move_uploaded_file($tmp, $nagyMappa . basename($nev));

            // KICSI
            copy($nagyMappa . basename($nev), $kicsiMappa . basename($nev));

            echo "Kép feltöltve!";

        } else {
            $mappa = "dokumentaciok/";
            if (!is_dir($mappa)) mkdir($mappa, 0755, true);
            move_uploaded_file($tmp, $mappa . basename($nev));
            echo "Dokumentáció feltöltve a Dokumentaciok mappába!";
        }
    }
}
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="p-3">
<div class="container rounded bg-primary">
<div class="row p-3">
<h2>Fájl feltöltése</h2>
<form action="infex.php" method="post" enctype="multipart/form-data" class="mb-3">
    <input type="file" name="fileToUpload" id="fileToUpload" required>
    <input type="submit" value="Feltöltés" class="btn btn-success">
</form>
</div>

<div class="row p-3 bg-secondary">
    <div class="d-flex flex-wrap">
<?php
$kicsiMappa = "kepek/kicsi/";
if (is_dir($kicsiMappa)) {
   
    $kepek = glob($kicsiMappa . "*.{jpg,png,}", GLOB_BRACE);
    foreach ($kepek as $kep) {
        $src = htmlspecialchars($kep, ENT_QUOTES);
        echo "<div style='margin:5px;'><img src='$src' class='img-fluid img-thumbnail' style='border:1px solid #ccc; max-width:100px;'></div>";
    }
}
?>
</div>
</div>
</div>


<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
