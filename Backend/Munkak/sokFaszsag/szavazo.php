<?php
session_start();








if (isset($_GET['inlineRadioOptions'])) 
    {
    if($_GET['inlineRadioOptions'] != "eredo"){
     if(!isset($_SESSION['szavazatok']))
{
    $_SESSION['szavazatok'] = [];
}
        
    
    if (array_key_exists($_GET['inlineRadioOptions'], $_SESSION['szavazatok'])) {
        $_SESSION['szavazatok'][$_GET['inlineRadioOptions']]++;
    } else {
        $_SESSION['szavazatok'][$_GET['inlineRadioOptions']] = 1;

    }


    
}
else{
    var_dump($_SESSION['szavazatok']);
}
}


?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Szavazás</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <style>
        body {
            background-color: #d9ecffff;
           
        }
        .btn-17,
.btn-17 *,
.btn-17 :after,
.btn-17 :before,
.btn-17:after,
.btn-17:before {
  border: 0 solid;
  box-sizing: border-box;
}

.btn-17 {
  -webkit-tap-highlight-color: transparent;
  -webkit-appearance: button;
  background-color: #003375ff;
  background-image: none;
  color: #fff;
  cursor: pointer;
  font-family: ui-sans-serif, system-ui, -apple-system, BlinkMacSystemFont,
    Segoe UI, Roboto, Helvetica Neue, Arial, Noto Sans, sans-serif,
    Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol, Noto Color Emoji;
  font-size: 100%;
  font-weight: 900;
  line-height: 1.5;
  margin: 0;
  -webkit-mask-image: -webkit-radial-gradient(#000, #fff);
  padding: 0;
  text-transform: uppercase;
}

.btn-17:disabled {
  cursor: default;
}

.btn-17:-moz-focusring {
  outline: auto;
}

.btn-17 svg {
  display: block;
  vertical-align: middle;
}

.btn-17 [hidden] {
  display: none;
}

.btn-17 {
  border-radius: 99rem;
  border-width: 2px;
  padding: 0.8rem 3rem;
  z-index: 0;
}

.btn-17,
.btn-17 .text-container {
  overflow: hidden;
  position: relative;
}

.btn-17 .text-container {
  display: block;
  mix-blend-mode: difference;
}

.btn-17 .text {
  display: block;
  position: relative;
}

.btn-17:hover .text {
  -webkit-animation: move-up-alternate 0.3s forwards;
  animation: move-up-alternate 0.3s forwards;
}

@-webkit-keyframes move-up-alternate {
  0% {
    transform: translateY(0);
  }

  50% {
    transform: translateY(80%);
  }

  51% {
    transform: translateY(-80%);
  }

  to {
    transform: translateY(0);
  }
}

@keyframes move-up-alternate {
  0% {
    transform: translateY(0);
  }

  50% {
    transform: translateY(80%);
  }

  51% {
    transform: translateY(-80%);
  }

  to {
    transform: translateY(0);
  }
}

.btn-17:after,
.btn-17:before {
  --skew: 0.2;
  background: #fff;
  content: "";
  display: block;
  height: 102%;
  left: calc(-50% - 50% * var(--skew));
  pointer-events: none;
  position: absolute;
  top: -104%;
  transform: skew(calc(150deg * var(--skew))) translateY(var(--progress, 0));
  transition: transform 0.2s ease;
  width: 100%;
}

.btn-17:after {
  --progress: 0%;
  left: calc(50% + 50% * var(--skew));
  top: 102%;
  z-index: -1;
}

.btn-17:hover:before {
  --progress: 100%;
}

.btn-17:hover:after {
  --progress: -102%;
}
.switch {
  position: relative;
  width: 210px;
  height: 50px;
  box-sizing: border-box;
  padding: 3px;
  background: #0d0d0d;
  border-radius: 6px;
  box-shadow:
    inset 0 1px 1px 1px rgba(0, 0, 0, 0.5),
    0 1px 0 0 rgba(255, 255, 255, 0.1);
}
.switch input[type="checkbox"] {
  position: absolute;
  z-index: 1;
  width: 100%;
  height: 100%;
  opacity: 0;
  cursor: pointer;
}
.switch input[type="checkbox"] + label {
  position: relative;
  display: block;
  left: 0;
  width: 50%;
  height: 100%;
  background: #1b1c1c;
  border-radius: 3px;
  box-shadow: inset 0 1px 0 0 rgba(255, 255, 255, 0.1);
  transition: all 0.5s ease-in-out;
}
.switch input[type="checkbox"] + label:before {
  content: "";
  display: inline-block;
  width: 5px;
  height: 5px;
  margin-left: 10px;
  background: #fff;
  border-radius: 50%;
  vertical-align: middle;
  box-shadow:
    0 0 5px 2px rgba(165, 15, 15, 0.9),
    0 0 3px 1px rgba(165, 15, 15, 0.9);
  transition: all 0.5s ease-in-out;
}
.switch input[type="checkbox"] + label:after {
  content: "";
  display: inline-block;
  width: 0;
  height: 100%;
  vertical-align: middle;
}
.switch input[type="checkbox"] + label i {
  display: block;
  position: absolute;
  top: 50%;
  left: 50%;
  width: 3px;
  height: 24px;
  margin-top: -12px;
  margin-left: -1.5px;
  border-radius: 2px;
  background: #0d0d0d;
  box-shadow: 0 1px 0 0 rgba(255, 255, 255, 0.3);
}
.switch input[type="checkbox"] + label i:before,
.switch input[type="checkbox"] + label i:after {
  content: "";
  display: block;
  position: absolute;
  width: 100%;
  height: 100%;
  border-radius: 2px;
  background: #0d0d0d;
  box-shadow: 0 1px 0 0 rgba(255, 255, 255, 0.3);
}
.switch input[type="checkbox"] + label i:before {
  left: -7px;
}
.switch input[type="checkbox"] + label i:after {
  left: 7px;
}
.switch input[type="checkbox"]:checked + label {
  left: 50%;
}
.switch input[type="checkbox"]:checked + label:before {
  box-shadow:
    0 0 5px 2px rgba(15, 165, 70, 0.9),
    0 0 3px 1px rgba(15, 165, 70, 0.9);

}

    </style>
</head>
<body>
    <div class="container  mt-3">
    <div class="switch">
  <input id="toggle" type="checkbox" />
  <label class="toggle" for="toggle">
    <i></i>
  </label>
</div>
    </div>


    <div class="container">
        <div class="row">   
            <div class="col-12 text-center my-4">
                <h1>Szavazás</h1>
            </div>
            <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="get">
            <div class="form-check ">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1">
  <label class="form-check-label" for="inlineRadio1">Tidesz</label>
</div>
<div class="form-check ">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2">
  <label class="form-check-label" for="inlineRadio2">Duna</label>
</div>
            <div class="form-check ">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" value="option3">
  <label class="form-check-label" for="inlineRadio3">Mások háza</label>
</div>
<div class="form-check ">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio4" value="option4">
  <label class="form-check-label" for="inlineRadio4">Kutyám-Majom</label>
</div>
            <div class="form-check ">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio5" value="option5">
  <label class="form-check-label" for="inlineRadio5">Bravo</label>
</div>
<input type="submit" value="Szavazok" class="btn mt-3 btn-17">

</form>
<div <?php foreach($_SESSION['szavazatok']as $partok ){
    echo $partok;
}?>></div>
        </div>
    </div>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>