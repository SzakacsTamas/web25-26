<?php
session_start();

if(!isset($_SESSION["emailTipusok"])) {
    $_SESSION["emailTipusok"] = [];
}

if(isset($_GET["email"]) && $_GET["email"] !== "") {
    $tipus = explode("@", $_GET["email"]);

    // csak akkor fusson, ha tényleg van domain rész
    if(isset($tipus[1])) {
        if(array_key_exists($tipus[1], $_SESSION["emailTipusok"])) {
            $_SESSION["emailTipusok"][$tipus[1]]++;
        } else {
            $_SESSION["emailTipusok"][$tipus[1]] = 1;
        }
    }
}

if(isset($_GET["del"])) {
    unset($_SESSION["emailTipusok"]);
    
}
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <title>Email domain számláló</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            margin: 20px;
            background-image: URL('hatter.jpg');
            color: white;
        }

    </style>
</head>
<body>
    <div class="container mt-4">
        <h2>Email domain számláló</h2>
        <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="get" class="mb-3">
            <label for="email" class="form-label">Email cím: </label>
            <input type="email" name="email" id="email" class="form-control w-50 d-inline">
            <input type="submit" value="Küldés">
            <input type="submit" value="Összes törlése" id="del" name="del" >
        </form>

        <h3>Statisztika:</h3>
       
            <?php 
             echo "<ul>";
            if(!empty($_SESSION["emailTipusok"])){
                foreach($_SESSION["emailTipusok"] as $domain => $db){
                    echo "<li>" . $domain . " → " . $db . "</li>"; 
                   
                }
                    
            }
                 else{
                    echo  "Még nincs adat";
                        
                 } 

            echo "</ul>";
                
        ?>
    </div>
</body>
</html>