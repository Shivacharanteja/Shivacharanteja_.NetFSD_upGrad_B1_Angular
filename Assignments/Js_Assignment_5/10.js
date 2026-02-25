class MathUtils {
  static add(a, b) {
    return a + b;
  }
  static subtract(a, b) {
    return a - b;
  }
  static multiply(a, b) {
    return a * b;
  }
}
console.log(`Addition: ${MathUtils.add(10, 20)}`);
console.log(`Subtraction: ${MathUtils.subtract(50, 20)}`);
console.log(`Multiplication: ${MathUtils.multiply(5, 6)}`);