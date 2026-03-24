using System;
using Microsoft.Data.SqlClient;
namespace Ado.NetAssignment1
{
    internal class Exercise1
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source=Shiva\\SqlExpress;Initial Catalog=Ado.NetAssignment1;Integrated Security=True;Trust Server Certificate=True";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                while (true)
                {
                    Console.WriteLine("\n1.Insert  2.View  3.Update  4.Delete  5.Exit");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Age: ");
                            int age = int.Parse(Console.ReadLine());

                            Console.Write("Grade: ");
                            string grade = Console.ReadLine();

                            command.CommandText = "INSERT INTO Students (Name, Age, Grade) VALUES (@Name,@Age,@Grade)";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Age", age);
                            command.Parameters.AddWithValue("@Grade", grade);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Inserted Successfully");
                            break;

                        case 2:
                            command.CommandText = "SELECT * FROM Students";
                            command.Parameters.Clear();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"{reader["Id"]} {reader["Name"]} {reader["Age"]} {reader["Grade"]}");
                                }
                            }
                            break;

                        case 3:
                            Console.Write("Enter Id: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("New Grade: ");
                            string newGrade = Console.ReadLine();

                            command.CommandText = "UPDATE Students SET Grade=@Grade WHERE Id=@Id";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Grade", newGrade);
                            command.Parameters.AddWithValue("@Id", id);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Updated Successfully");
                            break;

                        case 4:
                            Console.Write("Enter Id: ");
                            int delId = int.Parse(Console.ReadLine());

                            command.CommandText = "DELETE FROM Students WHERE Id=@Id";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Id", delId);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Deleted Successfully");
                            break;

                        case 5:
                            return;
                    }
                }
            }
        }
    }
}
