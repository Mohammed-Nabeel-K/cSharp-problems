namespace weekTwoDayFive.MiddleWare
{
    public class CustomMiddlewareInterface : IMiddleware
    {
        public CustomMiddlewareInterface() { }

        public async Task InvokeAsync(HttpContext context,RequestDelegate next)
        {
            Console.WriteLine("before Imiddleware");
            await next(context);
            Console.WriteLine("After Imiddleware");
        }
    }
}
