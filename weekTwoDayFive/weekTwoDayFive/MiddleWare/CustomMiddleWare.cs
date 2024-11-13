using Microsoft.AspNetCore.Mvc;

namespace weekTwoDayFive.MiddleWare
{
    public class CustomMiddleWare 
    {
        public RequestDelegate _next;

        public CustomMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
           
            Console.WriteLine("before");
            await _next(context);
            
            
            Console.WriteLine("after ");
        }
    }
}
