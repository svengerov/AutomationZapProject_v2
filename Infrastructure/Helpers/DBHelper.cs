using Microsoft.Data.SqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers
{
    public class DBHelper
    {
        public string connection_string="";

        public DBHelper(string db_server, string db_name) 
        {
            this.connection_string = $@"Server={db_server};Database={db_name};Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public void InsertData(string insert_query,string username, string email)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connection_string))
                {
                    // Open the connection
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insert_query, connection))
                    {
                        // Define the parameters and their values
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@UserEmail", email);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Display result
                        Console.WriteLine($"Rows inserted: {rowsAffected}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting data: " + ex.Message);
            }
        }

        public void ReadData(string select_query)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connection_string))
                {
                    // Open the connection
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(select_query, connection))
                    {
                        // Execute the query and read the data
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if there are rows
                            if (reader.HasRows)
                            {
                                Console.WriteLine("UserID\tUserName\t\tUserEmail");

                                while (reader.Read())
                                {
                                    // Read the values from each row
                                    int userId = reader.GetInt32(0);
                                    string userName = reader.GetString(1);
                                    string userEmail = reader.GetString(2);

                                    Console.WriteLine($"{userId}\t{userName}\t{userEmail}");
                                }
                            }
                           

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading data: " + ex.Message);
            }
        }
    }
}
