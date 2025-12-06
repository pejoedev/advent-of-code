const fs = require('fs');
const path = require('path');

// Load input.txt as text
const inputPath = path.join(__dirname, 'input.txt');
const inputText = fs.readFileSync(inputPath, 'utf8');

console.log("Input loaded:");
console.log(inputText.substring(0, 100) + "..."); // Show first 100 characters
console.log(`Total length: ${inputText.length} characters`);
console.log(`---------------------------------------------------`);

let inputSplitted = inputText.split('\n')
let list1 = inputSplitted[0].split(" ");
let list2 = inputSplitted[1].split(" ");
let list3 = inputSplitted[2].split(" ");
let list4 = inputSplitted[3].split(" ");

list1 = list1.filter((el) => {
    if (el != "") return el
})
list2 = list2.filter((el) => {
    if (el != "") return el
})
list3 = list3.filter((el) => {
    if (el != "") return el
})
list4 = list4.filter((el) => {
    if (el != "") return el
})
totals = [];
for (let i = 0; i < list1.length; i++) {
    if (list4[i] == "+") {
        totals.push(Number(list1[i]) + Number(list2[i]) + Number(list3[i]))
    } else {
        totals.push(Number(list1[i]) * Number(list2[i]) * Number(list3[i]))
    }
}
total = 0;
totals.forEach(element => {
    total += element
});
console.log(total)