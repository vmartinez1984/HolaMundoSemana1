using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.Middleware.v1.Middleware
{
    public class ApikeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApikeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {                        
            var existHeader = context.Request.Headers.TryGetValue("apikey", out var value);
            if (!existHeader)
            {
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Title = "Unauthorized",
                    Detail = "No se ingreso la apikey",
                    Status = StatusCodes.Status401Unauthorized
                };
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsJsonAsync(problemDetails);

                return;
            }

            if (value != "1234")
            {
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Title = "Unauthorized",
                    Detail = "La apikey es incorrecta",
                    Status = StatusCodes.Status401Unauthorized
                };
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsJsonAsync(problemDetails);

                return;
            }
            await _next(context);
        }
    }
}
