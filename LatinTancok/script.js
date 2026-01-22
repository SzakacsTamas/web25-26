let adatok = [];
let tancok = {};
fetch("backend.php")
.then((res) =>res.text())
.then((txt)=>{
    console.log(txt)



})
function feladat1() {
    fetch("tancrend.txt")
        .then((res) => res.blob())
        .then((txt) => {
            const fajl = new FormData();
            fajl.append("file", txt, "tancrend.txt");

            return fetch("backEnd.php", {
                method: "POST",
                body: fajl,
            })
                .then((res) => res.json())
                .then((valasz) => {
                    valasz[0].forEach((elem) => {
                        let tancok = document.createElement("option");
                        tancok.innerHTML = elem;
                        document.getElementById("tancok").appendChild(tancok);
                        let tancok2 = document.createElement("option");
                        tancok2.innerHTML = elem;
                        document.getElementById("tancok2").appendChild(tancok2);
                    });
                    valasz[1].forEach((elem) => {
                        let lany = document.createElement("option");
                        lany.innerHTML = elem;
                        let lany2 = document.createElement("option");
                        lany2.innerHTML = elem;
                  
                        document.getElementById("osszesTancos").appendChild(lany);
                        document.getElementById("osszesTancos2").appendChild(lany2);
                    });
                    valasz[2].forEach((elem) => {
                        let fiu = document.createElement("option");
                        fiu.innerHTML = elem;
                        let fiu2 = document.createElement("option");
                        fiu2.innerHTML = elem;
                       
                        document.getElementById("osszesTancos").appendChild(fiu);
                        document.getElementById("osszesTancos2").appendChild(fiu2);
                    });
                });
        });
}


function feladat2() {
    fetch("backend.php", {
        method: "POST",
        body: JSON.stringify({
            feladat: "2",
        }),
    })
        .then((x) => x.json())
        .then((valasz) => {
            document.getElementById("feladat2Doboz").innerHTML='2.Feladat<br>'+"Az elsőként bemutatott tánc a(az) " + valasz.elsoTanc + " volt, az utolsóként bemutatott pedig a(az) " + valasz.utolsoTanc + " volt.";
        });
}

function feladat3() {
    fetch("backEnd.php", {
        method: "POST",
        body: JSON.stringify({
            feladat: "3",
            tanc: document.getElementById("tancok").value,
        }),
    })
        .then((x) => x.json())
        .then((valasz) => {
           document.getElementById("feladat3Doboz").innerHTML='3.Feladat<br>'+ document.getElementById("tancok").value+ "-t ennyien táncolták: "+valasz+"<br>";
        });
}

function feladat4() {
    fetch("backEnd.php", {
        method: "POST",
        body: JSON.stringify({
            feladat: "4",
            tancos: document.getElementById("osszesTancos").value
        }),
    })
        .then((x) => x.json())
        .then((valasz) => {
            document.getElementById("feladat4Doboz").innerHTML='4.Feladat<br>'+document.getElementById("osszesTancos").value+": "+valasz;
        });
}

function feladat5() {
    fetch("backend.php", {
        method: "POST",
        body: JSON.stringify({
            feladat: "5",
            tancos: document.getElementById("osszesTancos2").value,
            tanc: document.getElementById("tancok2").value,
        }),
    })
        .then((x) => x.json())
        .then((valasz) => {
            if(valasz)
            {
                document.getElementById("feladat5Doboz").innerHTML='5.Feladat<br>'+"A " +document.getElementById("tancok2").value+" bemutatóján "+document.getElementById("osszesTancos2").value+" párja "+valasz +" volt";
            }
            else{
document.getElementById("feladat5Doboz").innerHTML='5.Feladat<br>'+ document.getElementById("osszesTancos2").value+" nem táncolt "+document.getElementById("tancok2").value+"-t";
            }
        });
}

function feladat6() {
    fetch("backend.php", {
        method: "POST",
        body: JSON.stringify({
            feladat: "6",
        }),
    })
        .then((x) => x.json())
        .then((valasz) => {
            document.getElementById("feladat6Doboz").innerHTML='6.Feladat<br>'+"A legtöbbször táncolt személyek: "+valasz;
        });
}

function feladat7() {
    fetch("backend.php", {
        method: "POST",
        body: JSON.stringify({
            feladat: "7",
        }),
    })
        .then((x) => x.json())
        .then((valasz) => {
            document.getElementById("feladat7Doboz").innerHTML='7.Feladat<br>'+"A legtöbbször előadott tánc: "+valasz;
        });
}