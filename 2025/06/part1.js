const fs = require('fs');
const path = require('path');

// Load input.txt as text
const inputPath = path.join(__dirname, 'input.txt');
const inputText = fs.readFileSync(inputPath, 'utf8');

console.log("Input loaded:");
console.log(inputText.substring(0, 100) + "..."); // Show first 100 characters
console.log(`Total length: ${inputText.length} characters`);