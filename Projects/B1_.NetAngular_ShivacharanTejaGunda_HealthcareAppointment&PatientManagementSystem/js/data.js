/* ==================
LOCAL STORAGE HELPERS
=====================*/
function getData(key)
{
let data = localStorage.getItem(key)
return data ? JSON.parse(data) : []
}
function saveData(key,data)
{
localStorage.setItem(key,JSON.stringify(data))
}

/*=================
COMMON UTILITIES
=================*/
function formatTime(hour)
{
let h = parseInt(hour)
let suffix = h >= 12 ? "PM" : "AM"
let displayHour = h % 12
if(displayHour === 0) displayHour = 12
return displayHour + ":00 " + suffix
}
function generateId(prefix)
{
return prefix + "_" + Math.floor(Math.random()*100000)
}
function showAlert(message)
{
alert(message)
}
function confirmDelete()
{
return confirm("Are you sure you want to delete?")
}
/*===================
VALIDATION HELPERS
=====================*/
function isValidPhone(phone)
{
return /^[0-9]{10}$/.test(phone)
}
function isValidEmail(email)
{
return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)
}
function isValidAge(age)
{
return age && age > 0 && age <= 120
}
function showToast(message, type="success") {
    let toast = $("#toastMsg .toast-body");
    toast.removeClass("bg-success bg-danger bg-warning");
    
    if(type === "success") toast.addClass("bg-success");
    if(type === "error") toast.addClass("bg-danger");
    if(type === "warning") toast.addClass("bg-warning");

    toast.text(message);

    new bootstrap.Toast($("#toastMsg")).show();
}