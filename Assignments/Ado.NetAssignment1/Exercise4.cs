using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Ado.NetAssignment1
{
    internal class Exercise4
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source=Shiva\\SqlExpress;Initial Catalog=Ado.NetAssignment1;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                while (true)
                {
                    Console.WriteLine("\n1.Place Order  2.View Orders  3.Exit");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        // ✅ 1. Transaction (Order + Items)
                        case 1:
                            SqlTransaction transaction = connection.BeginTransaction();

                            try
                            {
                                SqlCommand command = connection.CreateCommand();
                                command.Transaction = transaction;

                                // Insert into Orders
                                Console.Write("Customer Name: ");
                                string cname = Console.ReadLine();

                                Console.Write("Total Amount: ");
                                decimal amount = decimal.Parse(Console.ReadLine());

                                command.CommandText = "INSERT INTO Orders (CustomerName, TotalAmount) VALUES (@Name,@Amount); SELECT SCOPE_IDENTITY();";
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@Name", cname);
                                command.Parameters.AddWithValue("@Amount", amount);

                                int orderId = Convert.ToInt32(command.ExecuteScalar());

                                // Insert multiple items
                                Console.Write("How many items: ");
                                int count = int.Parse(Console.ReadLine());

                                for (int i = 0; i < count; i++)
                                {
                                    Console.Write("Product Name: ");
                                    string pname = Console.ReadLine();

                                    Console.Write("Quantity: ");
                                    int qty = int.Parse(Console.ReadLine());

                                    command.CommandText = "INSERT INTO OrderItems (OrderId, ProductName, Quantity) VALUES (@OrderId,@Pname,@Qty)";
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@OrderId", orderId);
                                    command.Parameters.AddWithValue("@Pname", pname);
                                    command.Parameters.AddWithValue("@Qty", qty);

                                    command.ExecuteNonQuery();
                                }

                                // ✅ Commit if all success
                                transaction.Commit();
                                Console.WriteLine("Order placed successfully!");

                            }
                            catch (Exception ex)
                            {
                                // ❌ Rollback if any error
                                transaction.Rollback();
                                Console.WriteLine("Error occurred. Transaction rolled back.");
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        // ✅ 2. View Orders with Items
                        case 2:
                            SqlCommand viewCmd = connection.CreateCommand();

                            viewCmd.CommandText = @"SELECT o.OrderId, o.CustomerName, o.TotalAmount,
                                                    i.ProductName, i.Quantity
                                                    FROM Orders o
                                                    JOIN OrderItems i ON o.OrderId = i.OrderId";

                            using (SqlDataReader reader = viewCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"{reader["OrderId"]} {reader["CustomerName"]} {reader["TotalAmount"]} | {reader["ProductName"]} {reader["Quantity"]}");
                                }
                            }
                            break;

                        case 3:
                            return;
                    }
                }
            }
        }
    }
}
