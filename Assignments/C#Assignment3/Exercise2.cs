using System;

class Doctor
{
    public int DoctorId;
    public string DoctorName;
    public string Specialization;
    public double ConsultationFee;
}
class Exercise2
{
    static void Main()
    {
        Doctor d1 = new Doctor();
        Doctor d2 = new Doctor();

        d1.DoctorId = 1;
        d1.DoctorName = "Dr. Sharma";
        d1.Specialization = "Cardiologist";
        d1.ConsultationFee = 800;

        d2.DoctorId = 2;
        d2.DoctorName = "Dr. Mehta";
        d2.Specialization = "Dermatologist";
        d2.ConsultationFee = 500;

        Console.WriteLine("Doctor 1: " + d1.DoctorName + " - " + d1.Specialization + " Fee: " + d1.ConsultationFee);
        Console.WriteLine("Doctor 2: " + d2.DoctorName + " - " + d2.Specialization + " Fee: " + d2.ConsultationFee);
    }
}