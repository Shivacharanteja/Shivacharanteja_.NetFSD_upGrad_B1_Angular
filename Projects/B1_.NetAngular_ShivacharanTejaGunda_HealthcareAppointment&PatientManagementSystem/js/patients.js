let patients = getData("patients")
/*=============
RENDER PATIENT TABLE
===================*/
function renderPatients(list = patients)
{
let rows=""
list.forEach((p,index)=>{
rows+=`
<tr>
<td>${p.id}</td>
<td>${p.name}</td>
<td>${p.age}</td>
<td>${p.gender}</td>
<td>${p.phone}</td>
<td>${p.email}</td>
<td>${p.notes}</td>
<td>
<button class="btn btn-warning btn-sm"
onclick="editPatient(${index})">Edit</button>
<button class="btn btn-danger btn-sm"
onclick="deletePatient(${index})">
Delete
</button>
</td>
</tr>
`
})
if(rows === "")
{
rows = `<tr><td colspan="8" class="text-center">No patients found. Click "Add Patient" to create one.</td></tr>`
}
$("#patientTable").html(rows)
}
// Auto-generate sequential Patient IDs like P101, P102, ...
function getNextPatientID()
{
let patients = getData("patients")
if(patients.length === 0)
{
localStorage.setItem('lastPatientID', 100)
}
let last = localStorage.getItem('lastPatientID') || 100
last = parseInt(last) + 1
localStorage.setItem('lastPatientID', last)
return 'P' + last
}
/*============================
SAVE PATIENT (ADD / EDIT)
===========================*/
function savePatient() {
   let patientid = $("#patientId").val(); // hidden input value
   // Generate new ID if adding new patient
   let id = patientid || getNextPatientID();
   let patient = {
   id: id, // use generated or existing ID
   name: $("#name").val().trim(),
   age: $("#age").val(),
   gender: $("#gender").val(),
   phone: $("#phone").val().trim(),
   email: $("#email").val().trim(),
   notes: $("#notes").val().trim()
   }
   /*==============
   VALIDATIONS
   =============*/
if (!patient.name) {
   showAlert("Patient name is required");
   return;
}
if (!patient.phone) {
   showAlert("Phone number is required");
   return;
}
if(!isValidPhone(patient.phone)) {
   showAlert("Phone number must be exactly 10 digits");
   return;
}
if (!patient.email) {
   showAlert("Email is required", "warning");
   return;
}
if (patient.email && !isValidEmail(patient.email)) {
   showAlert("Enter valid email format");
   return;
}
if (!patient.age) {
   showAlert("Age is required", "warning");
   return;
}
if (patient.age && !isValidAge(patient.age)) {
   showAlert("Enter valid age");
   return;
}
/* ===================
ADD OR UPDATE PATIENT
=======================*/
if (patientid) {
    // Editing existing patient
   let index = patients.findIndex(p => p.id === patientid);
   patients[index] = patient;
} else {
   // Adding new patient
   patients.push(patient);
}
try {
   saveData("patients", patients);
   renderPatients();
   showToast("Patient saved successfully");
} catch (error) {
   handleError(error, "Error saving patient");
}
// close modal
$("#patientModal").modal("hide");
clearForm();
}
/*===========
EDIT PATIENT
=============*/
function editPatient(index)
{
let p = patients[index]
$("#patientId").val(p.id)
$("#name").val(p.name)
$("#age").val(p.age)
$("#gender").val(p.gender)
$("#phone").val(p.phone)
$("#email").val(p.email)
$("#notes").val(p.notes)
$("#patientModal").modal("show")
}
/*============
DELETE PATIENT
===============*/
function deletePatient(index)
{
let patientName = patients[index].name
let appointments = getData("appointments")
let used = appointments.some(a => 
a.patient === patientName && a.status === "Booked"
)
if(used)
{
showAlert("Cannot delete patient with existing appointments")
return
}
if(confirm("Are you sure you want to delete this patient?"))
{
try {
   patients.splice(index,1)
   saveData("patients",patients)
   renderPatients()
   showToast("Patient deleted successfully")
} catch(error) {
   handleError(error, "Error deleting patient")
}
}
}
/*==============
SEARCH PATIENT
===============*/
$("#searchPatient").on("keyup",function(){
let value = $(this).val().toLowerCase()
let filtered = patients.filter(p =>
p.name.toLowerCase().includes(value) ||
p.phone.includes(value)
)
renderPatients(filtered)
})
/*============
CLEAR FORM
================*/
function clearForm()
{
$("#patientId").val("")
$("#name").val("")
$("#age").val("")
$("#gender").val("Male")
$("#phone").val("")
$("#email").val("")
$("#notes").val("")
}
/*==============
INITIAL LOAD
===============*/
renderPatients()