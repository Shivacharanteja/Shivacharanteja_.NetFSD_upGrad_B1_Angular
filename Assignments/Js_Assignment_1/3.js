const purchaseAmount = 4500;
let discountPercentage = 0;
if (purchaseAmount >= 5000) {
    discountPercentage = 20;
} else if (purchaseAmount >= 3000) {
    discountPercentage = 10;
} else {
    discountPercentage = 0;
}
let discountAmount = (purchaseAmount * discountPercentage) / 100;
let finalPayableAmount = purchaseAmount - discountAmount;
console.log("Total Purchase: " + purchaseAmount);
console.log("Discount Applied: " + discountPercentage + "%");
console.log("Discount Amount: " + discountAmount);
console.log("Final Payable: " + finalPayableAmount);