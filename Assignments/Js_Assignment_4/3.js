let cart = [
  { id: 1, product: "Laptop", price: 60000, qty: 1 },
  { id: 2, product: "Headphones", price: 2000, qty: 2 },
  { id: 3, product: "Mouse", price: 800, qty: 1 }
];
console.log("\n1. Total Cart Value:");
let totalCartValue = cart.reduce((total, item) => {
  return total + (item.price * item.qty);
}, 0);
console.log("₹" + totalCartValue);
console.log("\n2. Increase Quantity (ID = 3):");
let updatedCart = cart.map(item => {
  if (item.id === 3) {
    return { ...item, qty: item.qty + 1 };
  }
  return item;
});
console.log(updatedCart);
console.log("\n3. Remove Product (ID = 2):");
let cartAfterRemoval = cart.filter(item => item.id !== 2);
console.log(cartAfterRemoval);
console.log("\n4. Apply 10% Discount (> ₹10,000):");
let discountedCart = cart.map(item => {
  if (item.price > 10000) {
    return {
      ...item,
      price: +(item.price * 0.9).toFixed(2)
    };
  }
  return item;
});
console.log(discountedCart);
console.log("\n5. Sort by Total Item Price:");
let sortedCart = [...cart].sort((a, b) => {
  return (a.price * a.qty) - (b.price * b.qty);
});
console.log(sortedCart);
console.log("\n6. Any product > ₹50,000?");
let expensiveItem = cart.some(item => item.price > 50000);
console.log(expensiveItem);
console.log("\n7. All items in stock?");
let allInStock = cart.every(item => item.qty > 0);
console.log(allInStock);
console.log("\nBONUS 1: Invoice Format");
let invoice = cart.map(item => 
  `${item.product} (x${item.qty}) - ₹${item.price * item.qty}`
).join("\n");
console.log(invoice);
console.log("\nBONUS 2: Most Expensive Product");
let mostExpensive = cart.reduce((max, item) => {
  return item.price > max.price ? item : max;
});
console.log(mostExpensive);
console.log("\nBONUS 3: GST Calculation");
let gst = +(totalCartValue * 0.18).toFixed(2);
let finalAmount = +(totalCartValue + gst).toFixed(2);
console.log("GST (18%): ₹" + gst);
console.log("Final Amount with GST: ₹" + finalAmount);