<?php
use App\Http\Controllers\Api\Controller;
use Illuminate\Support\Facades\Request;

Route::get('/test', [TestController::class, 'index']);

?>