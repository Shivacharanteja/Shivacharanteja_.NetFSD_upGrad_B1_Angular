$(document).ready(function(){
(function(){
const specializations = [
"Cardiologist",
"Dermatologist",
"Neurologist",
"Orthopedic",
"Doctor of Muscular Anatomy"
];
let doctors = getData("doctors")
function formatSlotDisplay(slot)
{
let parts = slot.split("-")
return formatTime(parts[0]) + " - " + formatTime(parts[1])
}
/*=====
RENDER
======= */
function renderDoctors(list = doctors)
{
let rows=""
list.forEach((d,index)=>{
rows+=`
<tr>
<td>${d.id}</td>
<td>${d.name}</td>
<td>${d.specialization}</td>
<td>${formatSlotDisplay(d.slot)}</td>
<td>
<button class="btn btn-warning btn-sm"
onclick="editDoctor(${index})">Edit</button>
<button class="btn btn-danger btn-sm"
onclick="deleteDoctor(${index})">Delete</button>
</td>
</tr>
`
})
if(rows === "")
{
rows = `<tr><td colspan="5" class="text-center">No doctors found. Click "Add Doctor" to create one.</td></tr>`
}
$("#doctorTable").html(rows)
}
/*==========
    ID
=========*/
function getNextDoctorID()
{
let doctors = getData("doctors")
if(doctors.length === 0)
{
localStorage.setItem('lastDoctorID', 100)
}
let last = localStorage.getItem('lastDoctorID') || 100
last = parseInt(last) + 1
localStorage.setItem('lastDoctorID', last)
return 'D' + last
}
/*====================
LOAD SPECIALIZATIONS
======================*/
function loadSpecializations()
{
let options=""
specializations.forEach(s=>{
options+=`<option>${s}</option>`
})
$("#specialization").html(options)
}
/*====
SAVE
=====*/
window.saveDoctor = function()
{
let id = $("#doctorId").val()
let name = $("#doctorName").val().trim()
let specialization = $("#specialization").val()
let rawSlot = $("#doctorSlot").val().trim()
let slotParts = rawSlot.split("-")
function convertTo24(time)
{
let [hour, rest] = time.trim().split(":")
let minutesPart = rest.split(" ")
let min = minutesPart[0]
let period = minutesPart[1]
hour = parseInt(hour)
if(period === "PM" && hour !== 12) hour += 12
if(period === "AM" && hour === 12) hour = 0
return hour
}
let start = convertTo24(slotParts[0])
let end = convertTo24(slotParts[1])
let slot = start + "-" + end
if (!name || !slot)
{
showAlert("All fields required")
return
}
let doctor = {
id: id || getNextDoctorID(),
name,
specialization,
slot
}
if(id)
{
let index = doctors.findIndex(d => d.id === id)
doctors[index] = doctor
}
else
{
doctors.push(doctor)
}
try {
    saveData("doctors", doctors)
    renderDoctors()
    showToast("Doctor saved successfully")
} catch(error) {
    handleError(error, "Error saving doctor")
}
$("#doctorModal").modal("hide")
clearDoctorForm()
}
/*===
EDIT
===*/
window.editDoctor = function(index)
{
let d = doctors[index]
$("#doctorId").val(d.id)
$("#doctorName").val(d.name)
$("#specialization").val(d.specialization)
$("#doctorSlot").val(formatSlotDisplay(d.slot))
$("#doctorModal").modal("show")
}
/*========
DELETE
=======*/
window.deleteDoctor = function(index)
{
let doctorName = doctors[index].name
let appointments = getData("appointments")
let used = appointments.some(a => 
a.doctor === doctorName && a.status === "Booked"
)
if(used)
{
showAlert("Cannot delete doctor with appointments")
return
}
if(confirmDelete())
{
try {
    doctors.splice(index,1)
    saveData("doctors", doctors)
    renderDoctors()
    showToast("Doctor deleted successfully")
} catch(error) {
    handleError(error, "Error deleting doctor")
}
}
}
/*=========
SEARCH
=========*/
$("#searchDoctor").on("keyup",function(){
let value = $(this).val().toLowerCase()
let filtered = doctors.filter(d =>
d.name.toLowerCase().includes(value)
)
renderDoctors(filtered)
})
/*=======
CLEAR
=========*/
function clearDoctorForm()
{
$("#doctorId").val("")
$("#doctorName").val("")
$("#specialization").val("Cardiologist")
$("#doctorSlot").val("")
}
/*======
 INIT 
 ========*/
loadSpecializations()
renderDoctors()
})()
})