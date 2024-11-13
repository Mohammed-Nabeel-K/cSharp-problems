
using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server = NABEEL; Database = test;Integrated Security=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            //connection.Open();
            //Console.WriteLine("Connection successful!");

            string query = "INSERT INTO Users VALUES (@username,@password) ";

            using (SqlCommand command = new SqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@username", "ajfar");
                command.Parameters.AddWithValue("@password", "ajfar");

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted");
            }

            query = "SELECT * FROM Users";

            using (SqlCommand command = new SqlCommand(query, connection)) 
            {
                
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    int id = reader.GetInt32(0);
                    string username = reader.GetString(1);
                    string password = reader.GetString(2);
                    Console.WriteLine($"id = {id},username = {username}, password = {password}");
                }
            }

        }
    }
}