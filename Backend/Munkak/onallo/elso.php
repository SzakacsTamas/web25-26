
<?php
session_start();

if(isset($_GET["nev1"])){
    $_SESSION["nev1"]=[];
}

if(isset($_GET["nev2"])){
    $_SESSION["nev2"]=[];
}

if(isset($_GET["nev1"])){
    $_SESSION["nev1"][]=$_GET["nev1"];

}
if(isset($_GET["nev2"])){
    $_SESSION["nev2"][]=$_GET["nev2"];

}
//var_dump($_SESSION);
$lista1="";
$lista2="";

for($i=0;$i<sizeof($_SESSION["nev1"]);$i++){
    $lista1.='<li class="">'.$_SESSION["nev1"][$i].'</li>';
}
for($i=0;$i<sizeof($_SESSION["nev2"]);$i++){
    $lista2.='<li class="">'.$_SESSION["nev2"][$i].'</li>';
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-12 col-lg-6 container">
    
    <form action="<?php echo $_SERVER["PHP_SELF"];?>" method="get">
        <div class="row">
            <div class="col-3">    <label for="nev1" class="form-label">Szó lista 1:</label>    </div>
        <div class="col-7"> <input type="text" name="nev1" id="nev1" class="form-control"></div>
        <div class="col-2"><input type="submit" value="Küldés"></div>
        
        </div>
        
    </form>
            </div>
                        <div class="col-12 col-lg-6 container">
    
    <form action="<?php echo $_SERVER["PHP_SELF"];?>" method="get">
        <div class="row">
            <div class="col-3">    <label for="nev2" class="form-label">Szó lista 2:</label>    </div>
        <div class="col-7"> <input type="text" name="nev2" id="nev2" class="form-control"></div>
        <div class="col-2"><input type="submit" value="Küldés"></div>
        
        </div>
        
    </form>
            </div>
        </div>
        
        <div class="row">
            <div class="col-12 col-lg-6">
                <ol>
                <?php echo $lista1;?>
                </ol>
            </div>
                        <div class="col-12 col-lg-6">
                <ul>
                <?php echo $lista2;?>
                </ul>
            </div>
        </div>
    </div>


</body>
</html>