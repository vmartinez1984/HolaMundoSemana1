using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace HolaMundo.Filtro.v1.Filters
{
    public class AutrorizacionBasicaFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var headerAuthorizationBasic = context.HttpContext.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(headerAuthorizationBasic))
            {
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Title = "No se han enviado las credenciales",
                    Detail = "Es necesario enviar el header Authorization con las credenciales en formato Basic.",
                    Status = 401
                };
                context.HttpContext.Response.StatusCode = 401;
                await context.HttpContext.Response.WriteAsJsonAsync(problemDetails);
                return;
            }

            var headerBase64 = headerAuthorizationBasic.ToString().Split(" ")[1];
            string headerDecoded = Encoding.UTF8.GetString(Convert.FromBase64String(headerBase64));
            string[] credentials = headerDecoded.Split(":");
            string username = credentials[0];
            string password = credentials[1];

            if (username == "usuario" && password == "contrasenia")
            {
                //Usuario valido
                var _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<AutrorizacionBasicaFilter>>();
                _logger.LogInformation("Usuario valido");
            }
            else
            {
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Title = "Unauthorized",
                    Detail = "Las credenciales son incorrectas",
                    Status = StatusCodes.Status401Unauthorized
                };
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.HttpContext.Response.WriteAsJsonAsync(problemDetails);
            }

            next();
        }
    }
}
