namespace HolaMundo.Loggin.v2.Middleware
{
    /// <summary>
    /// Middleware para captura y registrar el Request y el Response de las peticiones HTTP. 
    /// Se registra la URL, los headers, el body de la petición y el body de la respuesta, así como el status code y los headers de la respuesta.
    /// </summary>
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
            _logger.LogInformation("{id} Request Url:{url}", context.Connection.Id, context.Request.Path);
            string headers = string.Empty;
            foreach (var item in context.Request.Headers)
                _logger.LogInformation("{0} Request Headers {1}: {2}", context.Connection.Id, item.Key, item.Value);
            if (context.Request.ContentLength > 0)
            {
                string requestBody = string.Empty;
                // Log request body
                context.Request.EnableBuffering();
                requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;
                _logger.LogInformation("{id} Request body: {RequestBody}", context.Session.Id, requestBody);
            }
            //Costumers Headers
            context.Response.Headers.Add("autor", "unam");

            // Store the original body stream for restoring the response body back to its original stream
            var originalBodyStream = context.Response.Body;
            // Create new memory stream for reading the response; Response body streams are write-only, therefore memory stream is needed here to read
            await using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            // Set stream pointer position to 0 before reading
            memoryStream.Seek(0, SeekOrigin.Begin);
            // Read the body from the stream
            var responseBodyText = await new StreamReader(memoryStream).ReadToEndAsync();
            //set data response
            _logger.LogInformation("{id} Response body: {1}", context.Connection.Id, responseBodyText);
            // Reset the position to 0 after reading
            memoryStream.Seek(0, SeekOrigin.Begin);
            // Do this last, that way you can ensure that the end results end up in the response.
            // (This resulting response may come either from the redirected route or other special routes if you have any redirection/re-execution involved in the middleware.)
            // This is very necessary. ASP.NET doesn't seem to like presenting the contents from the memory stream.
            // Therefore, the original stream provided by the ASP.NET Core engine needs to be swapped back.
            // Then write back from the previous memory stream to this original stream.
            // (The content is written in the memory stream at this point; it's just that the ASP.NET engine refuses to present the contents from the memory stream.)
            context.Response.Body = originalBodyStream;
            await context.Response.Body.WriteAsync(memoryStream.ToArray());

            _logger.LogInformation("{id} StatusCode: {statusCode}", context.Connection.Id, context.Response.StatusCode);
            string headersResponse = string.Empty;
            foreach (var item in context.Response.Headers)
                //headersResponse += $"{item.Key} {item.Value}";            
                _logger.LogInformation("{id} Response headers {1}:{2}", context.Connection.Id, item.Key, item.Value);
        }
    }
}
