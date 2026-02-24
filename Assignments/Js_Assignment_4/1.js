let books = [
  { id: 1, title: "JavaScript Basics", price: 450, stock: 10 },
  { id: 2, title: "React Guide", price: 650, stock: 5 },
  { id: 3, title: "Node.js Mastery", price: 550, stock: 8 },
  { id: 4, title: "CSS Complete", price: 300, stock: 12 }
];

console.log("\n1. Book Titles:");
let titles = books.map(book => book.title);
console.log(titles);

console.log("\n2. Total Inventory Value:");
let totalValue = books.reduce((total, book) => {
  return total + (book.price * book.stock);
}, 0);
console.log("₹" + totalValue);

console.log("\n3. Books above ₹500:");
let costlyBooks = books.filter(book => book.price > 500);
console.log(costlyBooks);

console.log("\n4. Prices increased by 5%:");
let increasedPriceBooks = books.map(book => ({
  ...book,
  price: +(book.price * 1.05).toFixed(2)
}));
console.log(increasedPriceBooks);

console.log("\n5. Sorted by Price (Low → High):");
let sortedBooks = [...books].sort((a, b) => a.price - b.price);
console.log(sortedBooks);

console.log("\n6. Remove Book with ID = 2:");
let updatedBooks = books.filter(book => book.id !== 2);
console.log(updatedBooks);

console.log("\n7. Any book out of stock?");
let outOfStock = books.some(book => book.stock === 0);
console.log(outOfStock);

console.log("\nFind Book with ID = 3:");
let foundBook = books.find(book => book.id === 3);
console.log(foundBook);

console.log("\nBONUS 1: Group by Price Range:");
let groupedBooks = books.reduce((groups, book) => {
  if (book.price <= 400) {
    groups["Budget"] = groups["Budget"] || [];
    groups["Budget"].push(book);
  } else if (book.price <= 600) {
    groups["Standard"] = groups["Standard"] || [];
    groups["Standard"].push(book);
  } else {
    groups["Premium"] = groups["Premium"] || [];
    groups["Premium"].push(book);
  }
  return groups;
}, {});
console.log(groupedBooks);

console.log("\nBONUS 2: 10% Discount for books above ₹600:");
let discountedBooks = books.map(book => {
  if (book.price > 600) {
    return {
      ...book,
      price: +(book.price * 0.9).toFixed(2)
    };
  }
  return book;
});
console.log(discountedBooks);

console.log("\nBONUS 3: Invoice:");
let invoice = books
  .map(book => `${book.title} - ₹${book.price}`)
  .join("\n");

console.log(invoice);