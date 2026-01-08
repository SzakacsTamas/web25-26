<?php


$path = explode("/", trim($_SERVER["PATH_INFO"] ?? "", "/"));

function fakt($n) {
    if ($n < 0 || $n > 20) return null;
    $r = 1;
    for ($i = 1; $i <= $n; $i++) $r *= $i;
    return $r;
}

function haromszog($a, $b, $c) {
    if ($a + $b <= $c || $a + $c <= $b || $b + $c <= $a) return null;
    $s = ($a + $b + $c) / 2;
    return sqrt($s * ($s - $a) * ($s - $b) * ($s - $c));
}

$lorem = [];
for ($i = 1; $i <= 100; $i++) {
    $lorem[] = "Lorem ipsum mondat #$i.";
}

$action = $path[0] ?? "";

switch ($action) {

    case "fakt":
        $n = intval($path[1] ?? -1);
        $res = fakt($n);
        echo json_encode($res === null ? ["error"=>"Max 20!"] : ["result"=>$res]);
        break;

    case "szorzat":
        echo json_encode(["result" => intval($path[1]) * intval($path[2])]);
        break;

    case "haromszog":
        $t = haromszog(intval($path[1]), intval($path[2]), intval($path[3]));
        echo json_encode($t ? ["result"=>round($t,2)] : ["error"=>"Nem háromszög"]);
        break;

    case "random":
        if (count($path) == 2) {
            $r = rand(0, intval($path[1]));
        } elseif (count($path) == 3) {
            $r = rand(intval($path[1]), intval($path[2]));
        } else {
            $vals = range(intval($path[1]), intval($path[2]), intval($path[3]));
            $r = $vals[array_rand($vals)];
        }
        echo json_encode(["result"=>$r]);
        break;

    case "lorem":
        $n = intval($path[1]);
        echo json_encode(["result"=>implode(" ", array_slice($lorem, 0, $n))]);
        break;

    default:
        echo json_encode(["error"=>"Ismeretlen végpont"]);
}
