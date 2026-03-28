namespace HolaMundo.Loggin.v2.Middleware
{
    public class ResquestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResquestResponseMiddleware> _logger;

        public ResquestResponseMiddleware(RequestDelegate next, ILogger<ResquestResponseMiddleware> logger) 
        {
            this._next = next;
            this._logger = logger;
        }

        public void Invoke(HttpContext context) {

            string url = context.Request.Path;
            string headers = string.Empty;
            foreach (var item in context.Request.Headers) { 
                headers += $"{item.Key} {item.Value}";
            }

            _next(context);

            string headersResponse = string.Empty;
            foreach (var item in context.Response.Headers)
            {
                headersResponse += $"{item.Key} {item.Value}";
            }
            string statusCode = context.Response.StatusCode.ToString();
            //string bodyResponse = context.Response.Body;

            //_logger.LogInformation(
            //);
        }
    }
}
