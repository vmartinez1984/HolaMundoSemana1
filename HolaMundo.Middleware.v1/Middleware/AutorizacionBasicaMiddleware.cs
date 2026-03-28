using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.Middleware.v1.Middleware
{
    public class AutorizacionBasicaMiddleware
    {
        private readonly RequestDelegate _next;

        public AutorizacionBasicaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {                        
            
            
            await _next(context);
        }
    }
}
