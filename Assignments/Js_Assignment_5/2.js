class BankAccount {
  constructor(accountHolder, initialBalance = 0) {
    this.accountHolder = accountHolder;
    this.balance = initialBalance;
  }
  deposit(amount) {
    this.balance += amount;
    console.log(`Deposited: $${amount}. New balance: $${this.balance}`);
  }
  withdraw(amount) {
    if (amount > this.balance) {
      console.log("Insufficient funds! Cannot withdraw more than current balance.");
    } else {
      this.balance -= amount;
      console.log(`Withdrew: $${amount}. Remaining balance: $${this.balance}`);
    }
  }
  checkBalance() {
    console.log(`Account Holder: ${this.accountHolder} | Current Balance: $${this.balance}`);
  }
}
let myAccount = new BankAccount("Shivacharantej", 1000);
myAccount.deposit(500);
myAccount.withdraw(200);
myAccount.withdraw(2000);
myAccount.checkBalance();