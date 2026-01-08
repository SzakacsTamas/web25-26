<?php
session_start();
if(isset($_SESSION))
{
    echo $_SESSION["nev"];
    echo $_SESSION["email"];
    echo $_SESSION["telo"];
    echo $_SESSION["cim"];
    echo $_SESSION["jelszo"];
}
if(isset($_POST["lajos"]))
{
    session_destroy();
}

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <form action="<?php echo $_SERVER["PHP_SELF"]?>" method="post">
        <input type="submit" value="Törlés" name="lajos">;
    </form>
</body>
</html>