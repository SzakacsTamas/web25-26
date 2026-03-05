<?php

class Car {
    private $make;
    private $model;
    private $year;
    private $color;

    public function __construct($make, $model, $year, $color) {
        $this->make = $make;
        $this->model = $model;
        $this->year = $year;
        $this->color = $color;
    }

    public function getMake() {
        return $this->make;
    }

    public function getModel() {
        return $this->model;
    }

    public function getYear() {
        return $this->year;
    }

    public function getColor() {
        return $this->color;
    }

    public function setColor($color) {
        $this->color = $color;
    }

    public function displayInfo() {
        return "Make: " . $this->make . ", Model: " . $this->model . ", Year: " . $this->year . ", Color: " . $this->color;
    }
}

// Example usage
$myCar = new Car("Toyota", "Corolla", 2020, "Blue");
echo $myCar->displayInfo();

?>