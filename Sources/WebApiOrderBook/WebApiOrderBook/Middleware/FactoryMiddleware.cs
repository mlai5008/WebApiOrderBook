namespace WebApiOrderBook.Middleware
{
    public class FactoryMiddleware : IMiddleware
    {
        #region Fields
        private readonly ILogger<FactoryMiddleware> _logger;
        #endregion

        #region Сonstructor
        public FactoryMiddleware(ILogger<FactoryMiddleware> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Methods
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Before request");

            await next(context);

            _logger.LogInformation("After request");
        } 
        #endregion
    }
}
