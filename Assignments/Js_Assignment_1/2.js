const marks = 82;
let grade;
if (marks >= 75) {
    grade = "Grade A";
} else if (marks >= 60) {
    grade = "Grade B";
} else if (marks >= 40) {
    grade = "Grade C";
} else {
    grade = "Fail";
}
console.log("Student Marks: " + marks);
console.log("Result: " + grade);