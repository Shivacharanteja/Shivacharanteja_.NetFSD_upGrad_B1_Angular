class Vehicle {
  constructor(brand, speed) {
    this.brand = brand;
    this.speed = speed;
  }
  start() {
    console.log(`${this.brand} is starting at ${this.speed} km/h.`);
  }
}
class Car extends Vehicle {
  constructor(brand, speed, fuelType) {
    super(brand, speed); 
    this.fuelType = fuelType;
  }
  showDetails() {
    this.start(); 
    console.log(`Fuel Type: ${this.fuelType}`);
  }
}
const myCar = new Car("Toyota", 120, "Petrol");
myCar.showDetails();