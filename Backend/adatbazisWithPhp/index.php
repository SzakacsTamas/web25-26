<?php
$servername = "localhost";
$username = "root";
$password = "";


// Create connection
$conn = mysqli_connect($servername, $username, $password); 
// Check connection
if (!$conn) { 
  die("Connection failed: " . mysqli_connect_error());
}

// Create database
$sql = "CREATE DATABASE IF NOT EXISTS php";
if (mysqli_query($conn, $sql)) {
  echo "Database created successfully";
} else {
  echo "Error creating database: " . mysqli_error($conn);
}

mysqli_select_db($conn,"php");
$query="INSERT INTO `adatok` (`adat1`, `adat2`, `adat3`, `adat4`) VALUES ('12', 'valami', '2025-11-21', 'másikszöveg')";

//mysqli_close($conn,$query);
$query="SELECT adat1,adat4 FROM adatok";
//mysqli_query($conn,$query);
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  while($row = mysqli_fetch_assoc($result)) {
    echo "id: " . $row["adat1"]. " - Name: " . $row["adat4"]. " " . $row["lastname"]. "<br>";
  }
} 
else {
  echo "0 results";
}

mysqli_close($conn);
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