

function logout(){
    localStorage.token ="";
     location="index.html";
}
function login(){
 fetch('http://localhost/web25-26/rest_api_full/rest_api_jwt_full/backend/api/login.php',{
  method:'POST',
  headers:{'Content-Type':'application/json'},
  body:JSON.stringify({username:u.value,password:p.value})
 })
 .then(r=>r.json())
 .then(d=>{
    console.log(d);
    if(d.error){
        alert(d.error);
    }
    else
    {
        localStorage.token =d.token;
        location="dashboard.html"
    }

 });
}

function reg(){
 fetch('http://localhost/web25-26/rest_api_full/rest_api_jwt_full/backend/api/register.php',{
  method:'POST',
  headers:{'Content-Type':'application/json'},
  body:JSON.stringify({username:u.value,password:p.value})
 })
 .then(r=>r.json())
 .then(()=>{alert('Registered');

    location="index.html";
 });
}

