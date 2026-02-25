class Product {
  constructor({ name, price, category = "General" }) {
    this.name = name;
    this.price = price;
    this.category = category;
  }
  getDetails = () => {
    return `${this.name} (${this.category}) costs ₹${this.price}`;
  };
  applyDiscount = (discountPercent) => {
    const discountedPrice = this.price * (1 - discountPercent / 100);
    return { ...this, price: discountedPrice };
  };
}
const productData = { name: "Laptop", price: 85000 };
const p1 = new Product(productData);
console.log(p1.getDetails()); 
const saleProduct = p1.applyDiscount(10);
console.log(`Sale Price: ₹${saleProduct.price}`);