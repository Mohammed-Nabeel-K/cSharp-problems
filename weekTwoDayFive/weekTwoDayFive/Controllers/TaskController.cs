using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace weekTwoDayFive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [Authorize(Roles = "admin,user")]
        [HttpPost]
        public IActionResult Post() 
        {
            return Ok();
        }
        [Authorize(Roles = "admin,user")]
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public IActionResult Delete() 
        {
            return Ok();
        }
    }
}
