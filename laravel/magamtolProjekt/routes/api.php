<?php
use App\Http\Controllers\Api\TestController;
use App\Http\Controllers\Api\osszeAd;
use App\Http\Controllers\Api\szamol;
use Illuminate\Support\Facades\Route;


Route::get('/test', [TestController::class, 'index']);
Route::post('/szamol', [szamol::class, 'index']);