class Employee {
  constructor(name, salary) {
    this.name = name;
    this.salary = salary;
  }
  getDetails() {
    return `Employee Name: ${this.name}, Base Salary: ${this.salary}`;
  }
}
class Manager extends Employee {
  constructor(name, salary, bonus) {
    super(name, salary);
    this.bonus = bonus;
  }
  getTotalSalary() {
    return this.salary + this.bonus;
  }
}
class Director extends Manager {
  constructor(name, salary, bonus, stockOptions) {
    super(name, salary, bonus);
    this.stockOptions = stockOptions;
  }
  getFullCompensation() {
    return this.getTotalSalary() + this.stockOptions;
  }
}
const director1 = new Director("Shivacharantej", 100000, 20000, 50000);
console.log(director1.getDetails()); 
console.log(`Total Salary (Base + Bonus): ${director1.getTotalSalary()}`);
console.log(`Full Compensation (Incl. Stocks): ${director1.getFullCompensation()}`);