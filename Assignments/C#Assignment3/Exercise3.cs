using System;

class Hospital
{
    public static string HospitalName;
    public static string HospitalAddress;

    public string PatientName;
}

class Exercise3
{
    static void Main()
    {
        Hospital.HospitalName = "City Hospital";
        Hospital.HospitalAddress = "Hyderabad";

        Hospital p1 = new Hospital();
        Hospital p2 = new Hospital();
        Hospital p3 = new Hospital();

        p1.PatientName = "Ravi";
        p2.PatientName = "Suresh";
        p3.PatientName = "Mahesh";

        Console.WriteLine(Hospital.HospitalName + " - " + Hospital.HospitalAddress);
        Console.WriteLine("Patient: " + p1.PatientName);
        Console.WriteLine("Patient: " + p2.PatientName);
        Console.WriteLine("Patient: " + p3.PatientName);
    }
}
