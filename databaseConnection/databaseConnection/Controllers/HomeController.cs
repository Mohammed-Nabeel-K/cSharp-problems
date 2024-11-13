using databaseConnection.Model;
using databaseConnection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace databaseConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public readonly IuserServices _userServices;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration,IuserServices services){
            _configuration = configuration;
            _userServices = services;
        }

        [HttpPost]
        public IActionResult getAllData(userModel user)
        {
            try
            {
                 _userServices.postData(user);
            }
            catch(SqlException e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }

        [HttpGet]
        public IActionResult getUserInfo() {
            var record = _userServices.GetAllRecords();
            return Ok(record);

        }

        [HttpDelete]
        public IActionResult deleteUserInfo() {
            
            return Ok();
        }


    }
}
