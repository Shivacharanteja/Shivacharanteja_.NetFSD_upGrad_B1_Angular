using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace Ado.NetAssignment1
{
    internal class Exercise2
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source=Shiva\\SqlExpress;Initial Catalog=Ado.NetAssignment1;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                while (true)
                {
                    Console.WriteLine("\n1.Insert  2.View by Dept  3.Update Salary  4.Delete  5.Count  6.Exit");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        // ✅ 1. Insert using Stored Procedure
                        case 1:
                            Console.Write("Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Salary: ");
                            decimal salary = decimal.Parse(Console.ReadLine());

                            Console.Write("Department: ");
                            string dept = Console.ReadLine();

                            command.CommandText = "InsertEmployee";
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Salary", salary);
                            command.Parameters.AddWithValue("@Department", dept);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Inserted Successfully");
                            break;

                        // ✅ 2. Fetch by Department
                        case 2:
                            Console.Write("Enter Department: ");
                            string d = Console.ReadLine();

                            command.CommandText = "SELECT * FROM Employees WHERE Department=@Dept";
                            command.CommandType = CommandType.Text;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Dept", d);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"{reader["EmpId"]} {reader["Name"]} {reader["Salary"]} {reader["Department"]}");
                                }
                            }
                            break;

                        // ✅ 3. Update Salary using Stored Procedure
                        case 3:
                            Console.Write("EmpId: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("New Salary: ");
                            decimal newSal = decimal.Parse(Console.ReadLine());

                            command.CommandText = "UpdateSalary";
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@EmpId", id);
                            command.Parameters.AddWithValue("@Salary", newSal);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Updated Successfully");
                            break;

                        // ✅ 4. Delete using Parameterized Query
                        case 4:
                            Console.Write("EmpId: ");
                            int delId = int.Parse(Console.ReadLine());

                            command.CommandText = "DELETE FROM Employees WHERE EmpId=@Id";
                            command.CommandType = CommandType.Text;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Id", delId);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Deleted Successfully");
                            break;

                        // ✅ 5. Count Employees (ExecuteScalar example)
                        case 5:
                            command.CommandText = "SELECT COUNT(*) FROM Employees";
                            command.CommandType = CommandType.Text;

                            command.Parameters.Clear();

                            int count = (int)command.ExecuteScalar();
                            Console.WriteLine($"Total Employees: {count}");
                            break;

                        case 6:
                            return;
                    }
                }
            }
        }
    }
}
