let employees = [
    { id: 1, name: "Ravi", dept: "IT", salary: 70000 },
    { id: 2, name: "Anita", dept: "HR", salary: 50000 },
    { id: 3, name: "Karan", dept: "IT", salary: 80000 },
    { id: 4, name: "Meena", dept: "Finance", salary: 60000 }
];
const totalExpense = employees.reduce((sum, emp) => sum + emp.salary, 0);
console.log("Total Salary Expense: ₹", totalExpense);
const highestPaid = employees.reduce((max, emp) => emp.salary > max.salary ? emp : max);
const lowestPaid = employees.reduce((min, emp) => emp.salary < min.salary ? emp : min);
console.log("Highest Paid:", highestPaid.name, "| Lowest Paid:", lowestPaid.name);
const updatedSalaries = employees.map(emp => 
    emp.dept === "IT" ? { ...emp, salary: emp.salary * 1.15 } : emp
);
console.log("Updated IT Salaries:", updatedSalaries);
const groupedByDept = employees.reduce((acc, emp) => {
    (acc[emp.dept] = acc[emp.dept] || []).push(emp.name);
    return acc;
}, {});
console.log("Grouped by Dept:", groupedByDept);
const deptAverages = Object.keys(groupedByDept).map(deptName => {
    const deptEmps = employees.filter(emp => emp.dept === deptName);
    const avg = deptEmps.reduce((sum, e) => sum + e.salary, 0) / deptEmps.length;
    return { department: deptName, averageSalary: avg };
});
console.log("Dept-wise Averages:", deptAverages);
const sortedEmployees = [...employees].sort((a, b) => b.salary - a.salary);
console.log("Sorted (High to Low):", sortedEmployees);
const avgSalary = totalExpense / employees.length;
const bonusAnalytics = employees
    .map(emp => ({ ...emp, takeHome: emp.salary * 0.9 }))
    .filter(emp => emp.salary > avgSalary);
console.log("Employees Earning Above Average (with Tax applied):", bonusAnalytics);
const tableRows = employees.map(emp => 
    <tr><td>${emp.id}</td><td>${emp.name}</td><td>${emp.dept}</td><td>${emp.salary}</td></tr>
).join("");
const htmlTable = <table border="1"><thead><tr><th>ID</th><th>Name</th><th>Dept</th><th>Salary</th></tr></thead><tbody>${tableRows}</tbody></table>;
console.log("HTML Table String Generated!");