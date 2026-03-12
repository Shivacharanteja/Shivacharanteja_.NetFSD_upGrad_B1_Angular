using System;

class Appointment
{
    public int AppointmentId;
    public string PatientName;
    public string DoctorName;
    public DateTime AppointmentDate;

    public Appointment()
    {
        DoctorName = "General Physician";
        AppointmentDate = DateTime.Today;
    }
}

class Exercise4
{
    static void Main()
    {
        Appointment a = new Appointment();

        a.AppointmentId = 201;
        a.PatientName = "Ravi";

        Console.WriteLine("Appointment Id: " + a.AppointmentId);
        Console.WriteLine("Patient Name: " + a.PatientName);
        Console.WriteLine("Doctor Name: " + a.DoctorName);
        Console.WriteLine("Date: " + a.AppointmentDate);
    }
}
