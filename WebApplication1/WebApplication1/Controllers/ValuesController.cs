using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        private readonly string _connection;
        public ValuesController(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }
        [HttpPost]
        public IActionResult addData([FromBody] string value,string mail) {
            
            string usernnn = "";
            int userid = 0;
            string name = "";

            using (var connection = new SqlConnection(_connection))
            {
                using (var cmd = new SqlCommand("nnn", connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", value);
                    cmd.Parameters.Add("@output", SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@email", mail).Direction = ParameterDirection.InputOutput;
                    cmd.ExecuteNonQuery();

                    usernnn = cmd.Parameters["@output"].Value.ToString();
                    userid = (int)cmd.Parameters["@id"].Value;
                    name = cmd.Parameters["@email"].Value.ToString();

                }
                return Ok(usernnn +" "+ userid + " "+ name);

            }
        }

        [HttpGet]
        public IActionResult getName( string name)
        {
            string email = "";

            using (var connection = new SqlConnection(_connection))
            {
                using (var command = new SqlCommand("aaa", connection))
                {

                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    var emailParam = new SqlParameter("@name", SqlDbType.VarChar, 100)
                    {
                        Value = name,
                        Direction = ParameterDirection.InputOutput
                    };
                    command.Parameters.Add(emailParam);
                    command.ExecuteNonQuery();

                    email = emailParam.Value?.ToString() ?? string.Empty;


                }
            }
            return Ok(email);
        }
    
    }
}
