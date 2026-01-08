<?php
    session_start();
    //session_destroy();
    if(!isset($_SESSION["elso"]))
    {
        $_SESSION["elso"] = 1;
    }
    else
    {
        $_SESSION["elso"]++;
    }
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Első</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <div class="row">
            <nav aria-label="Page navigation example">
                <ul class="pagination justify-content-center">   
                    <li class="page-item active"><a class="page-link" href="elso.php">1</a></li>
                    <li class="page-item"><a class="page-link" href="masodik.php">2</a></li>
                    <li class="page-item"><a class="page-link" href="harmadik.php">3</a></li>
                    <li class="page-item"><a class="page-link" href="negyedik.php">4</a></li>
                </ul>
            </nav>
            <div class="h1 text-center">
                <label for="">Az oldal megnyitásainak száma: <?php echo $_SESSION["elso"]; ?></label>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>