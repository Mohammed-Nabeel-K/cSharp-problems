using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using weekTwoDayFive.Models;
using weekTwoDayFive.Services;

namespace weekTwoDayFive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthssController : ControllerBase
    {
        public readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        List<int> nums = new List<int>() { 1,2,3,4,5,6,7,8,9,10};

        [HttpGet("nums")]
        public  IActionResult getData(int id)
        {
            var res = nums.Where(x => x == id).FirstOrDefault();
            if(res != 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        public AuthssController(IUserServices userServices, IConfiguration config)
        {
            _userServices = userServices;
            _configuration = config;
        }

        [HttpPost("register")]
        public IActionResult Register(UserModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _userServices.Register(user);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel user)
        {
            try
            {
                var u = _userServices.Login(user);
                if (user == null)
                {
                    return BadRequest("Invald username or password");
                }
                string token = CreateToken(u);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server eroor");
            }
        }
        [Authorize]
        [HttpGet]
        
        public IActionResult GetUsers()
        {
            var userdata = _userServices.getAllStudents();
            if (userdata == null)
                return NoContent();

            return Ok(userdata);
        }

        private string CreateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Name,user.Usename),
                new Claim (ClaimTypes.Role, user.Roles)
            };

            var token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddMinutes(10)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
            

        }
    }
}
