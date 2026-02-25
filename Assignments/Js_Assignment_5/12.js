class Wallet {
  #balance = 0;
  addMoney(amount) {
    this.#balance += amount;
    console.log(`Added ₹${amount}.`);
  }
  spendMoney(amount) {
    if (amount <= this.#balance) {
      this.#balance -= amount;
      console.log(`Spent ₹${amount}.`);
    } else {
      console.log("Insufficient funds!");
    }
  }
  getBalance() {
    return `Current Balance: ₹${this.#balance}`;
  }
}