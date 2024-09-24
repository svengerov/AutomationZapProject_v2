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
        

       
        public static void InsertData(string originCurrency,string targetCurrency,int originCurrencyAmount,float targetCurrencyAmount,SqlConnection connection)
        {
            
            try
            {
                string insert_query = "INSERT INTO CurrencyRates (currentDate, originCurrency, originCurrencyAmount, targetCurrency, targetCurrencyAmount) " +
              "VALUES (@currentDate, @originCurrency, @originCurrencyAmount, @targetCurrency, @targetCurrencyAmount)";
                using (SqlCommand command = new SqlCommand(insert_query, connection))
                    {
                    // Define the parameters and their values
                    command.Parameters.AddWithValue("@currentDate", DateTime.Now);
                    command.Parameters.AddWithValue("@originCurrency", originCurrency);
                    command.Parameters.AddWithValue("@originCurrencyAmount", originCurrencyAmount);
                    command.Parameters.AddWithValue("@targetCurrency", targetCurrency);
                    command.Parameters.AddWithValue("@targetCurrencyAmount", targetCurrencyAmount);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                        // Display result
                        Console.WriteLine($"Rows inserted: {rowsAffected}");
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting data: " + ex.Message);
            }
        }

        public static void ReadData(string select_query, SqlConnection connection)
        {
            
            try
            {
             
                    using (SqlCommand command = new SqlCommand(select_query, connection))
                    {
                        // Execute the query and read the data
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if there are rows
                            if (reader.HasRows)
                            {                              

                                while (reader.Read())
                                {
                                    // Read the values from each row
                                    int param0 = reader.GetInt32(0);
                                    DateTime param1 = reader.GetDateTime(1);
                                    string param2 = reader.GetString(2);
                                    int param3 = reader.GetInt32(3);
                                    string param4 = reader.GetString(4);
                                    float param5 = reader.GetFloat(5);

                                Console.WriteLine($"{param0}\t{param1}\t{param2}\t{param3}\t{param4} {param5}");
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
