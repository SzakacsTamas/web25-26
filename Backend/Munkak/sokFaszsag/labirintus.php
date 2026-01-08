<?php
function d($elem){
    echo "<pre>";
    var_dump($elem);
    echo "</pre>";
}

function tablaKeszit()
{
    global $config;
    
    $vissza="";
    $vissza.="<table>";
    for($sor=0;$sor<$config["sor"];$sor++)
        {
            $vissza.="<tr>";
            for($cella=0;$cella<$config["oszlop"];$cella++)
                {
                    $gombSzin="";
                    if(isset($_SESSION["labirintus"][$sor][$cella]) && $_SESSION["labirintus"][$sor][$cella])
                    {
                        $gombSzin=" fal";
                    }
                    $vissza.="<td><input class=\"".$gombSzin."\" type=\"submit\" name=\"gomb-".$sor."-".$cella."\" value=\"\"></td>";
                }
            $vissza.="</tr>";
        }
    $vissza.="</table>";

    return $vissza;
}

function mentettLabirintusRajzol($id)
{
    $vissza="";
    global $config;
    $vissza.='<div>';
    for($sor=0;$sor<$config["sor"];$sor++)
    {
        $vissza.='<div style="font-size: 0">';
        for($oszlop=0;$oszlop<$config["oszlop"];$oszlop++)
        {
            if(isset($_SESSION["MentettLabirintusok"][$id][$sor][$oszlop]) && $_SESSION["MentettLabirintusok"][$id][$sor][$oszlop])
            {
                $vissza.=' <div style="border: 1px solid black; width:5px; height:5px; display:inline-block; background-color:black"></div>';
            }
            else
            {
                $vissza.=' <div style="border: 1px solid black; width:5px; height:5px; display:inline-block;"></div>';
            }
            
        }
        $vissza.='</ div>';
    }
    $vissza.='</div>';

    return $vissza;
};
    session_start();
    $config["oszlop"]=10;
    $config["sor"]=10;

    if(isset($_GET))
    {
        //TÖRLÉS
        if(isset($_GET["new"]) && $_GET["new"] == 1)
        {
            $_SESSION["labirintus"]=[];
        };

    

        $t=array_keys($_GET);

        foreach($t as $elem)
            {
                //echo $elem;
                if(str_starts_with($elem,"gomb-"))
                {
                    $darabok=explode("-",$elem);
                    if(sizeof($darabok)==3)
                    {
                        if(isset($_SESSION["labirintus"][$darabok[1]][$darabok[2]]) && $_SESSION["labirintus"][$darabok[1]][$darabok[2]]) 
                        {
                            $_SESSION["labirintus"][$darabok[1]][$darabok[2]]=false;   
                        }
                        else
                        {
                            $_SESSION["labirintus"][$darabok[1]][$darabok[2]]=true;
                        }
                    }
                }
            }
    }

   // d($_SESSION["labirintus"]);

   //d($_SESSION);
   //labirintus mentése
   if(isset($_GET["save"]))
   {
        $_SESSION["MentettLabirintusok"][$_GET["save"]]=$_SESSION["labirintus"];


   }


    $kisKep="";
    $tablaKesz=tablaKeszit();
    if(isset($_SESSION["MentettLabirintusok"]))
    {
        $t=array_keys($_SESSION["MentettLabirintusok"]);
        

        foreach($t as $id)
            {
                $kisKep .=mentettLabirintusRajzol($id);
            }
    
    }
       
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Labirintus</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <style>
        table{
            border: 2px solid black;
        }
        td{
            border: 1px solid black;
            width: 30px;
            height: 30px;}
        td input[type=submit]
        {
            width: 100%;
            height: 100%;
        }
        input.fal
        {
            background-color: blue;
        }
        form > div
        {
            display: inline-block;
            margin: 5px;
        }
    </style>
</head>
<body>
    <h1>Labirintus Készítő</h1>
    <form action="<?php echo $_SERVER['PHP_SELF'];?>" method="get">
    <?php echo $tablaKesz; ?>
    <button type="submit" name="save" value="1">Labirintus mentése</button><br>
    <button type="submit" name="new" value="1">Új labirintus</button><br>
        <?php echo $kisKep?>;
    </form>
    
</body>
</html>