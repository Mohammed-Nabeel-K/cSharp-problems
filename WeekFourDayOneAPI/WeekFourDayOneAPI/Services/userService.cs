using Microsoft.AspNetCore.Mvc;

namespace WeekFourDayOneAPI.Services
{
    public interface IuserService
    {
        string getData();
        string addData();

    }
    public class userService : IuserService
    {
        string getData() {
            return "hi" ;
        }
    }
}
