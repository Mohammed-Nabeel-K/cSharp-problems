using Microsoft.AspNetCore.Mvc;

namespace WeekFourDayOneAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult getData()
        {
            return Ok();
        }
    }
}
