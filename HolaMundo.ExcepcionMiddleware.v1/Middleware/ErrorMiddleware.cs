using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.ExcepcionMiddleware.v1.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context) {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error inesperado en el servidor.");
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Status = 500,
                    Title = "Error Interno del Servidor",
                    Detail = "Ocurrio un error inesperado en el servidor. Por favor intente nuevamente mas tarde."
                };            

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
