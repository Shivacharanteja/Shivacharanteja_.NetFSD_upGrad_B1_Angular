$(document).ready(function(){
(function(){
let appointments = getData("appointments")
let patients = getData("patients")
let doctors = getData("doctors")
/*=================
 GENERATE TIME SLOTS
 ================== */
function generateSlots(slot)
{
let parts = slot.split("-")
let start = parseInt(parts[0])
let end = parseInt(parts[1])
let duration = parseInt($("#duration").val()) || 1
let slots = []
let i = start
while(i < end)
{
let slotStart = i
let slotEnd = i + duration
if(slotEnd > end) break
if(slotStart < 13 && slotEnd > 13)
{
i = 14
continue
}
let display = formatTime(slotStart) + " - " + formatTime(slotEnd)
slots.push({
value: slotStart + "-" + slotEnd,
text: display
})
i += duration
}
return slots
}
/*====================
     DROPDOWNS
=================== */
function populateDropdowns()
{
if(patients.length === 0)
{
$("#patientDropdown").html(`<option disabled selected>No patients available</option>`)
}
else
{
let patientOptions=""
patients.forEach(p=>{
patientOptions+=`<option value="${p.name}">${p.name}</option>`
})
$("#patientDropdown").html(patientOptions)
}
if(doctors.length === 0)
{
$("#doctorDropdown").html(`<option>No doctors available</option>`)
}
else
{
let doctorOptions=""
doctors.forEach((d,index)=>{
doctorOptions+=`<option value="${index}">${d.name}</option>`
})
$("#doctorDropdown").html(doctorOptions)
}
}
if(patients.length === 0 || doctors.length === 0)
{
$("#bookBtn").prop("disabled", true)
}
else
{
$("#bookBtn").prop("disabled", false)
}
/*=========
LOAD SLOTS 
=========*/
function loadSlots()
{
let doctorIndex = $("#doctorDropdown").val()
let doctor = doctors[doctorIndex]
if(!doctor) return
let slots = generateSlots(doctor.slot)
let slotOptions=""
slots.forEach(s=>{
slotOptions+=`<option value="${s.value}">${s.text}</option>`
})
$("#appointmentSlot").html(slotOptions)
}
$("#doctorDropdown").on("change", loadSlots)
$("#duration").on("change", loadSlots)
/*==========
STATUS BADGE
===========*/
function getStatusBadge(status)
{
if(status=="Booked")
return `<span class="badge bg-primary">Booked</span>`
if(status=="Completed")
return `<span class="badge bg-success">Completed</span>`
if(status=="Cancelled")
return `<span class="badge bg-danger">Cancelled</span>`
}
/*==================
RENDER APPOINTMENTS
===================*/
function renderAppointments(list = appointments)
{
let rows=""
list.forEach(a=>{
rows+=`
<tr>
<td>${a.id}</td>
<td>${a.patient}</td>
<td>${a.doctor}</td>
<td>${a.date}</td>
<td>${formatTime(a.slot.split("-")[0])} - ${formatTime(a.slot.split("-")[1])}</td>
<td>${getStatusBadge(a.status)}</td>
<td>
<button class="btn btn-warning btn-sm"
onclick="editAppointment('${a.id}')">Edit</button>
<button class="btn btn-danger btn-sm"
onclick="deleteAppointment('${a.id}')">Delete</button>
</td>
</tr>
`
})
if(rows === "")
{
rows = `<tr><td colspan="7" class="text-center">No appointments found. Click "Book Appointment" to book one.</td></tr>`
}
$("#appointmentTable").html(rows)
}
/*===========
ID GENERATOR
============*/
function getNextAppointmentID()
{
let appointments = getData("appointments")
if(appointments.length === 0)
{
localStorage.setItem('lastAppointmentID', 100)
}
let last = localStorage.getItem('lastAppointmentID') || 100
last = parseInt(last) + 1
localStorage.setItem('lastAppointmentID', last)
return 'A' + last
}
/*======
DELETE
======*/
window.deleteAppointment = function(id)
{
if(confirmDelete())
{
try {
    appointments = appointments.filter(a => a.id !== id)
    saveData("appointments", appointments)
    renderAppointments()
    showToast("Appointment deleted successfully")
} catch(error) {
    handleError(error, "Error deleting appointment")
}
}
}
/*===
EDIT
====*/
window.editAppointment = function(id)
{
let a = appointments.find(x => x.id === id)
$("#patientDropdown").val(a.patient)
$("#doctorDropdown").val(doctors.findIndex(d => d.name === a.doctor))
$("#date").val(a.date)
$("#status").val(a.status)
loadSlots()
setTimeout(()=>{
$("#appointmentSlot").val(a.slot)
},100)
$("#appointmentModal").modal("show")
window.editingAppointmentId = id
}
/*=====
BOOK
=====*/
window.bookAppointment = function()
{
if(doctors.length === 0 || patients.length === 0)
{
showAlert("Please add doctor and patient first")
return
}
let patient = $("#patientDropdown").val()
let doctorIndex = $("#doctorDropdown").val()
let doctorObj = doctors[doctorIndex]
if(!doctorObj) return
let doctor = doctorObj.name
let doctorSlot = doctorObj.slot
let date = $("#date").val()
let slot = $("#appointmentSlot").val()
let status = $("#status").val()
if (!patient || !doctor || !date || !slot)
{
showAlert("All fields are required")
return
}
let [docStart, docEnd] = doctorSlot.split("-").map(Number)
let [start, end] = slot.split("-").map(Number)
if (start < docStart || end > docEnd)
{
showAlert("Outside doctor time")
return
}
let exists = appointments.find(a => {
if(window.editingAppointmentId && a.id === window.editingAppointmentId)
{
return false
}
let [s,e] = a.slot.split("-").map(Number)
return a.doctor === doctor &&
      a.date === date &&
      !(end <= s || start >= e)
})
if (exists)
{
showAlert("Doctor already has appointment in this slot")
return
}
let appointment = {
id: window.editingAppointmentId || getNextAppointmentID(),
patient,
doctor,
date,
slot,
status
}
if(window.editingAppointmentId)
{
let index = appointments.findIndex(a => a.id === window.editingAppointmentId)
appointments[index] = appointment
window.editingAppointmentId = null
}
else
{
appointments.push(appointment)
}
try {
    saveData("appointments", appointments)
    renderAppointments()
    showToast("Appointment saved successfully")
} catch(error) {
    handleError(error, "Error saving appointment")
}
$(".modal").modal("hide")
$("#date").val("")
$("#appointmentSlot").val("")
$("#status").val("Booked")
}
/*====
FILTER
======*/
window.applyFilters = function()
{
let status=$("#filterStatus").val()
let date=$("#filterDate").val()
let filtered=appointments.filter(a=>{
let statusMatch = status ? a.status===status : true
let dateMatch = date ? a.date===date : true
return statusMatch && dateMatch
})
renderAppointments(filtered)
}
/*=========
CLEAR ALL
=========*/
window.clearAllAppointments = function()
{
if(confirm("Delete ALL appointments?"))
{
appointments = []
try {
    appointments = []
    saveData("appointments", appointments)
    renderAppointments()
    showToast("All appointments cleared")
} catch(error) {
    handleError(error, "Error clearing appointments")
}
}
}
/*===
INIT
=====*/
populateDropdowns()
renderAppointments()
if(doctors.length > 0)
{
$("#doctorDropdown").val(0)
loadSlots()
}
})()
})