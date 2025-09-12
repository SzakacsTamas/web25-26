// This file contains the JavaScript code that handles the logic for the LED matrix simulation.

const rows = 5; // Number of rows in the LED matrix
const cols = 5; // Number of columns in the LED matrix
const ledMatrix = []; // Array to hold the LED elements

// Create the LED grid
function createLedGrid() {
    const gridContainer = document.getElementById('ledGrid');
    for (let i = 0; i < rows; i++) {
        const row = [];
        const rowDiv = document.createElement('div');
        rowDiv.className = 'led-row';
        for (let j = 0; j < cols; j++) {
            const led = document.createElement('div');
            led.className = 'led';
            led.style.backgroundColor = '#000'; // Default color is off (black)
            led.addEventListener('click', () => updateLedColor(led));
            rowDiv.appendChild(led);
            row.push(led);
        }
        gridContainer.appendChild(rowDiv);
        ledMatrix.push(row);
    }
}

// Update the color of the LED based on the color picker input
function updateLedColor(led) {
    const colorPicker = document.getElementById('colorPicker');
    led.style.backgroundColor = colorPicker.value;
}

// Initialize the LED matrix simulation
function init() {
    createLedGrid();
}

// Run the initialization function when the DOM is fully loaded
document.addEventListener('DOMContentLoaded', init);