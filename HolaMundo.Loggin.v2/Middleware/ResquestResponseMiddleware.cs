using System.Text;

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

        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path;
            string headers = string.Empty;
            foreach (var item in context.Request.Headers)
                headers += $"{item.Key} {item.Value}";
            string requestBody = string.Empty;
            if (context.Request.ContentLength > 0)
            {
                context.Request.EnableBuffering();
                requestBody = await new StreamReader(context.Request.Body, Encoding.UTF8).ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            _logger.LogInformation("Request Url: " + url);
            _logger.LogInformation("Request Headers: " + headers);
            _logger.LogInformation("Request body" + requestBody);
            context.Response.Headers.Add("autor", "unam");

            await _next(context);

            string headersResponse = string.Empty;
            foreach (var item in context.Response.Headers)
                headersResponse += $"{item.Key} {item.Value}";
            string statusCode = context.Response.StatusCode.ToString();

            await using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            // Call the next middleware
            await _next(context);

            // Set stream pointer position to 0 before reading
            memoryStream.Seek(0, SeekOrigin.Begin);

            // Read the body from the stream
            var responseBodyText = await new StreamReader(memoryStream).ReadToEndAsync();
            //set data response
            //AnalizeResponse(context, requestDtoIn, responseBodyText);
            //_ = _requestRepository.AgregarAsync(requestDtoIn);
            //// Reset the position to 0 after reading
            //memoryStream.Seek(0, SeekOrigin.Begin);

            
            //context.Response.Body = originalBodyStream;
            //await context.Response.Body.WriteAsync(memoryStream.ToArray());


            //_logger.LogInformation($"StatusCode: {statusCode}");
            //_logger.LogInformation($"Response headers: {headersResponse}");
            //_logger.LogInformation($"Response body: {responseText}");
        }
    }
}
