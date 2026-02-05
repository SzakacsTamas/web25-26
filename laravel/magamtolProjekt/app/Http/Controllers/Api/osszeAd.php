<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;

class szamol extends Controller
{
    public function index(request $request)
    {
        return response()->json([
            'szam1' => $request-> szam1,
            'szam2' => $request-> szam2,
            'osszead' => $request-> szam1+ $request -> szam2
        ]);
    }
}
