namespace WebApiOrderBook.Middleware
{
    public class FactoryMiddleware : IMiddleware
    {
        private readonly ILogger<FactoryMiddleware> _logger;

        public FactoryMiddleware(ILogger<FactoryMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Before request");

            await next(context);

            _logger.LogInformation("After request");
        }
    }
}
