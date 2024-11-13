using databaseConnection.Model;
using Microsoft.Data.SqlClient;

namespace databaseConnection.Services
{
    public interface IuserServices
    {
        public List<userModel> GetAllRecords();
        public void postData(userModel user);
        public void putData(userModel user);
        public void deleteData(userModel user);
    }

    public class userServices : IuserServices
    {
        private readonly string _connectionString;

        public userServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public void postData(userModel user)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string username = user.Username;
                    string password = user.Password;

                    connection.Open();
                    string query = "INSERT INTO Users(username,password) VALUES (@param1,@param2)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Param1", username);
                        command.Parameters.AddWithValue("@Param2", password);
                        int ss = command.ExecuteNonQuery();
                        Console.WriteLine(ss);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            

            
        }
        public List<userModel> GetAllRecords()
        {
            var records = new List<userModel>();

            using(var connection = new SqlConnection(_connectionString))
            {
                
                using (var command = new SqlCommand("SELECT * FROM Users", connection))
                {

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new userModel
                            {
                                Username = reader.GetString(reader.GetOrdinal("username")),
                                Password = reader.GetString(reader.GetOrdinal("password"))
                            };
                            records.Add(user);
                        }
                    }
                }
            }



            return records;
        }

        public void putData(userModel user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                
                string query = "UPDATE Users SET username = @username,password = @password WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int id = user.Id;
                    string username = user.Username;
                    string password = user.Password;
                    command.Parameters.Add("@username", username);
                    command.Parameters.Add("@password", password);
                    command.Parameters.Add("@id", id);
                }
            }
        }
    }
}
