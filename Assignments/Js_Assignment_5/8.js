class Payment {
  pay(amount) {
    console.log(`Processing a generic payment of ₹${amount}...`);
  }
}
class CreditCardPayment extends Payment {
  pay(amount) {
    console.log(`Paid ₹${amount} using Credit Card. (2% transaction fee applied)`);
  }
}
class UPIPayment extends Payment {
  pay(amount) {
    console.log(`Paid ₹${amount} using UPI. (Transaction ID generated)`);
  }
}
class CashPayment extends Payment {
  pay(amount) {
    console.log(`Paid ₹${amount} in Cash. (No digital record)`);
  }
}
function processPayment(paymentMethod, amount) {
  paymentMethod.pay(amount);
}
const myCC = new CreditCardPayment();
const myUPI = new UPIPayment();
const myCash = new CashPayment();
processPayment(myCC, 5000);
processPayment(myUPI, 1200);
processPayment(myCash, 300)