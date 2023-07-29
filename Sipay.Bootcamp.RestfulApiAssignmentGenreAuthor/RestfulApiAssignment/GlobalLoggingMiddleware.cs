namespace RestfulApiAssignment
{
    public class GlobalLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log the request here (you can customize the log format and destination)
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);
        }
    }
}
