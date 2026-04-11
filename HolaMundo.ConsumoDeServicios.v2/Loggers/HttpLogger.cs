using Microsoft.Extensions.Http.Logging;

namespace HolaMundo.ConsumoDeServicios.v2.Loggers
{
    public class HttpLogger : IHttpClientLogger
    {
        private readonly ILogger<HttpLogger> _logger;

        public HttpLogger(ILogger<HttpLogger> logger) { _logger = logger; }        

        public void LogRequestFailed(object context, HttpRequestMessage request, HttpResponseMessage response, Exception exception, TimeSpan elapsed)
        {
            throw new NotImplementedException();
        }

        public object LogRequestStart(HttpRequestMessage request)
        {
            //throw new NotImplementedException();
            return null;
        }

        public void LogRequestStop(object context, HttpRequestMessage request, HttpResponseMessage response, TimeSpan elapsed)
        {
            _logger.LogInformation(
                "Request: {method} {url} responded {statusCode} in {elapsed}ms", 
                request.Method, 
                request.RequestUri, 
                response.StatusCode, 
                elapsed.TotalMilliseconds
            );
        }
    }
}
