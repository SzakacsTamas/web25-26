<?php

use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('welcome');
});
Route::get('/randomMagamtol', function () {
    return view('randomMagamtol');
});
Route::view('/dashboard','dashboard');