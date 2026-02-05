<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Api\TestController;
use App\Http\Controllers\Api\osszeAd;

Route::get('/', function () {
    return view('welcome');
});
Route::get('/randomMagamtol', function () {
    return view('randomMagamtol');
});



Route::view('/dashboard','dashboard');
Route::view('/szamol','szamol');