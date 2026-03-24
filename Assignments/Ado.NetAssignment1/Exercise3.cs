using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ado.NetAssignment1
{
    internal class Exercise3
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source=Shiva\\SqlExpress;Initial Catalog=Ado.NetAssignment1;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                // ✅ Adapter + DataSet (Disconnected setup)
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Products");

                DataTable dt = ds.Tables["Products"];

                while (true)
                {
                    Console.WriteLine("\n1.View  2.Add  3.Update  4.Delete  5.Save  6.Exit");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        // ✅ 1. Display (from DataTable, NOT DB)
                        case 1:
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row.RowState != DataRowState.Deleted)
                                {
                                    Console.WriteLine($"{row["ProductId"]} {row["ProductName"]} {row["Price"]} {row["Stock"]}");
                                }
                            }
                            break;

                        // ✅ 2. Add (offline)
                        case 2:
                            DataRow newRow = dt.NewRow();

                            Console.Write("Product Name: ");
                            newRow["ProductName"] = Console.ReadLine();

                            Console.Write("Price: ");
                            newRow["Price"] = decimal.Parse(Console.ReadLine());

                            Console.Write("Stock: ");
                            newRow["Stock"] = int.Parse(Console.ReadLine());

                            dt.Rows.Add(newRow);
                            Console.WriteLine("Added (offline)");
                            break;

                        // ✅ 3. Update (offline)
                        case 3:
                            Console.Write("Enter Row Index: ");
                            int idx = int.Parse(Console.ReadLine());

                            Console.Write("New Price: ");
                            dt.Rows[idx]["Price"] = decimal.Parse(Console.ReadLine());

                            Console.WriteLine("Updated (offline)");
                            break;

                        // ✅ 4. Delete (offline)
                        case 4:
                            Console.Write("Enter Row Index: ");
                            int delIdx = int.Parse(Console.ReadLine());

                            dt.Rows[delIdx].Delete();
                            Console.WriteLine("Deleted (offline)");
                            break;

                        // ✅ 5. Push changes to DB
                        case 5:
                            adapter.Update(ds, "Products");
                            Console.WriteLine("Changes saved to database");
                            break;

                        case 6:
                            return;
                    }
                }
            }
        }
    }
}
