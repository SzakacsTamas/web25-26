<?php
include "fugvenyek.php";

$target_dir = "../IMAGES/";
$config["kepek"]["eredeti"]["dir"] = $target_dir . "Eredeti/";
$config["kepek"]["eredeti"]["width"] = 0;
$config["kepek"]["eredeti"]["height"] = 0;

$config["kepek"]["kicsi"]["dir"] = $target_dir . "Kicsi/";
$config["kepek"]["kicsi"]["width"] = 100;
$config["kepek"]["kicsi"]["height"] = 100;

$config["kepek"]["kozepes"]["dir"] = $target_dir . "Kozepes/";
$config["kepek"]["kozepes"]["width"] = 600;
$config["kepek"]["kozepes"]["height"] = 600;

$config["kepek"]["nagy"] = ["dir" => $target_dir . "Nagy/", "width" => 1000, "height" => 1000];

$target_file = $target_dir . "Eredeti/" . basename($_FILES["fileToUpload"]["name"]);
$uploadOk = 1;
$imageFileType = strtolower(pathinfo($target_file, PATHINFO_EXTENSION));
//echo $_SERVER["DOCUMENT_ROOT"];
//echo PATHINFO_EXTENSION;

if (isset($_POST["submit"])) {
    $check = getimagesize($_FILES["fileToUpload"]["tmp_name"]);
    if ($check !== false) {
        $uploadOk = 1;
    } else {
        $uploadOk = 0;
    }
}

if ($uploadOk == 0) {
} else {
    if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file)) {
        $meret = getimagesize($target_file);
        if ($meret[0] > $meret[1]) {
            $ujX = 100;
            $ujY = round((100 / $meret[0]) * $meret[1]);
        } else {
            $ujX = 100;
            $ujY = round((100 / $meret[1]) * $meret[0]);
        }
        $kicsi = imagecreatetruecolor($ujX, $ujY);
        $forras = imagecreatefrompng($target_file);

        imagecopyresampled($kicsi, $forras, 0, 0, 0, 0, $ujX, $ujY, $meret[0], $meret[1]);

        imagejpeg($kicsi, $target_dir . "Kicsi/" . basename($_FILES["fileToUpload"]["name"]));
    } else {
    }
}
?>
<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <form action="feltoltTovabbFejleszt.php" method="post" enctype="multipart/form-data">
        Select image to upload:
        <input type="file" name="fileToUpload" id="fileToUpload">
        <input type="submit" value="Upload Image" name="submit">
    </form>
</body>
</html>