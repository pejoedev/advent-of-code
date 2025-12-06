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
let list1 = []
let list2 = []
let list3 = []
let list4 = []
let list5 = []

lastI = 0;
for (let i = 0; i <= inputSplitted[0].length; i++) {
    if (i == inputSplitted[0].length) {
        list1.push(inputSplitted[0].slice(lastI, i))
        list2.push(inputSplitted[1].slice(lastI, i))
        list3.push(inputSplitted[2].slice(lastI, i))
        list4.push(inputSplitted[3].slice(lastI, i))
        continue;
    }
    if (
        inputSplitted[0][i] == " " &&
        inputSplitted[1][i] == " " &&
        inputSplitted[2][i] == " "
    ) {
        list1.push(inputSplitted[0].slice(lastI, i))
        list2.push(inputSplitted[1].slice(lastI, i))
        list3.push(inputSplitted[2].slice(lastI, i))
        list4.push(inputSplitted[3].slice(lastI, i))
        lastI = i;
    }
}
console.log(list1)
console.log(list2)
console.log(list3)
console.log(list4)
// totals = [];
// for (let i = 0; i < list1.length; i++) {
//     let sumLength = Math.max(list1[i].length, list2[i].length, list3[i].length)
//     numbers = []
//     for (let j = 0; j < sumLength; j++) {
//         let number = getAtLocation(list1[i], j) + getAtLocation(list2[i], j) + getAtLocation(list3[i], j)
//         numbers.push(number)
//     }
//     console.log(numbers)

// }
// total = 0;
// totals.forEach(element => {
//     total += element
// });

// function getAtLocation(listItem, location) {
//     if (listItem.length <= location) return ''
//     return listItem[location]
// }

// console.log(total)