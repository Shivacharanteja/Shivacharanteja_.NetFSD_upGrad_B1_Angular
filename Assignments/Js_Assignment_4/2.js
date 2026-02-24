let students = [
    { name: "Akhil", marks: 85 },
    { name: "Priya", marks: 72 },
    { name: "Ravi", marks: 90 },
    { name: "Meena", marks: 45 },
    { name: "Karan", marks: 30 }
];
const passedStudents = students.filter(s => s.marks >= 40);
console.log("Passed Students:", passedStudents);
const distinctionStudents = students.filter(s => s.marks >= 85);
console.log("Distinction Students:", distinctionStudents);
const totalMarks = students.reduce((sum, s) => sum + s.marks, 0);
const classAverage = totalMarks / students.length;
console.log("Class Average:", classAverage);
const topper = students.reduce((prev, current) => (prev.marks > current.marks) ? prev : current);
console.log("Topper:", topper.name);
const failedCount = students.filter(s => s.marks < 40).length;
console.log("Number of Failed Students:", failedCount);
const studentsWithGrades = students.map(s => {
    let grade;
    if (s.marks >= 85) grade = 'A';
    else if (s.marks >= 60) grade = 'B';
    else if (s.marks >= 40) grade = 'C';
    else grade = 'Fail';
    return { ...s, grade };
});
console.log("Students with Grades:", studentsWithGrades);
const leaderboard = [...students]
    .sort((a, b) => b.marks - a.marks)
    .map((s, index) => ({ ...s, rank: index + 1 }));
console.log("Leaderboard:", leaderboard);
const lowestMarks = Math.min(...students.map(s => s.marks));
const filteredStudents = students.filter(s => s.marks !== lowestMarks);
console.log("Remaining after removing lowest scorer:", filteredStudents);