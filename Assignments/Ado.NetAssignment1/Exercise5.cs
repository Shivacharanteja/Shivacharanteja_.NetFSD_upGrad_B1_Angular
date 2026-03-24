using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Ado.NetAssignment1
{
    internal class Exercise5
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
                    Console.WriteLine("\n1.Add Book  2.View Books  3.Update  4.Delete  5.Search  6.Exit");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        // ✅ 1. Add Book
                        case 1:
                            Console.Write("Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Author: ");
                            string author = Console.ReadLine();

                            Console.Write("Price: ");
                            decimal price = decimal.Parse(Console.ReadLine());

                            command.CommandText = "INSERT INTO Books (Title, Author, Price) VALUES (@Title,@Author,@Price)";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Title", title);
                            command.Parameters.AddWithValue("@Author", author);
                            command.Parameters.AddWithValue("@Price", price);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Book Added Successfully");
                            break;

                        // ✅ 2. View Books
                        case 2:
                            command.CommandText = "SELECT * FROM Books";
                            command.Parameters.Clear();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"{reader["BookId"]} {reader["Title"]} {reader["Author"]} {reader["Price"]}");
                                }
                            }
                            break;

                        // ✅ 3. Update Book
                        case 3:
                            Console.Write("BookId: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("New Price: ");
                            decimal newPrice = decimal.Parse(Console.ReadLine());

                            command.CommandText = "UPDATE Books SET Price=@Price WHERE BookId=@Id";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Price", newPrice);
                            command.Parameters.AddWithValue("@Id", id);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Updated Successfully");
                            break;

                        // ✅ 4. Delete Book
                        case 4:
                            Console.Write("BookId: ");
                            int delId = int.Parse(Console.ReadLine());

                            command.CommandText = "DELETE FROM Books WHERE BookId=@Id";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Id", delId);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Deleted Successfully");
                            break;

                        // ✅ 5. Search Book by Name
                        case 5:
                            Console.Write("Enter Title: ");
                            string search = Console.ReadLine();

                            command.CommandText = "SELECT * FROM Books WHERE Title LIKE @Title";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Title", "%" + search + "%");

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"{reader["BookId"]} {reader["Title"]} {reader["Author"]} {reader["Price"]}");
                                }
                            }
                            break;

                        case 6:
                            return;
                    }
                }
            }
        }
    }
}
