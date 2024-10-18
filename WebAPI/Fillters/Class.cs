namespace WebAPI.Fillters
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "http://localhost:4200" });
                context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Authorization, Content-Type" });
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }

}
