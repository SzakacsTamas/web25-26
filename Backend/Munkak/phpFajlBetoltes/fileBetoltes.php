<?php
$myfile = fopen("ize.txt", "r") or die("Unable to open file!");
//echo fread($myfile,filesize("ize.txt"));
echo"<br>***************<br>";

while(!feof($myfile))
{
echo fgets($myfile) . "<br>";


}
fclose($myfile);
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    
</body>
</html>