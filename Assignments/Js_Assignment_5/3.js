class Student {
  constructor(name) {
    this.name = name;
    this.marks = [];
  }
  addMark(mark) {
    this.marks.push(mark);
  }
  getAverage() {
    if (this.marks.length === 0) return 0;
    const sum = this.marks.reduce((acc, curr) => acc + curr, 0);
    return sum / this.marks.length;
  }
  getGrade() {
    const average = this.getAverage();
    if (average >= 90) return "A";
    if (average >= 75) return "B";
    if (average >= 50) return "C";
    return "Fail";
  }
}
const student1 = new Student("Shivacharantej");
student1.addMark(85);
student1.addMark(92);
student1.addMark(78);
console.log(`${student1.name}'s Average: ${student1.getAverage().toFixed(2)}`);
console.log(`Final Grade: ${student1.getGrade()}`);