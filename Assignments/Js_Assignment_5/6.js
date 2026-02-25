class Shape {
  calculateArea() {
    return 0;
  }
}
class Circle extends Shape {
  constructor(radius) {
    super();
    this.radius = radius;
  }
  calculateArea() {
    return Math.PI * Math.pow(this.radius, 2);
  }
}
class Rectangle extends Shape {
  constructor(width, height) {
    super();
    this.width = width;
    this.height = height;
  }
  calculateArea() {
    return this.width * this.height;
  }
}
class Triangle extends Shape {
  constructor(base, height) {
    super();
    this.base = base;
    this.height = height;
  }
  calculateArea() {
    return 0.5 * this.base * this.height;
  }
}
const shapes = [
  new Circle(5),
  new Rectangle(10, 4),
  new Triangle(6, 8)
];
shapes.forEach((shape, index) => {
  console.log(`Shape ${index + 1} Area: ${shape.calculateArea().toFixed(2)}`);
});