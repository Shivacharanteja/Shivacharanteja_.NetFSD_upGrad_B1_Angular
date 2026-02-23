let num = 5;
let positivity = (num >= 0) ? "Positive" : "Negative";
console.log('The number is: ${positivity}');
if (num % 2 === 0) {
    console.log("The number is: Even");
} else {
    console.log("The number is: Odd");
}
console.log('Printing numbers from 1 to ${num}:');
for (let i = 1; i <= num; i++) {
    console.log(i);
}