<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h1> Szamolos Api</h1>
    <input type="text" id="szam1">
    <input type="text" id="szam2">

    <button onclick="loadApi()">Szamolás</button>
    <pre id="Apikimenet"></pre>

    <script>
        function loadApi() {
            const szam1 = document.getElementById('szam1').value;
            const szam2 = document.getElementById('szam2').value;

            fetch("/api/szamol")
            {
                method="post",
                headers={
                    "Content-Type":"application/json"
                },
                body=JSON.stringify({
                    szam1:szam1,
                    szam2:szam2
                }).then(res=>res.json())
                .then(data=>{
                    document.getElementById('Apikimenet').innerText=data.eredmeny;
                })
                
            }
        }
    </script>
</body>
</html>