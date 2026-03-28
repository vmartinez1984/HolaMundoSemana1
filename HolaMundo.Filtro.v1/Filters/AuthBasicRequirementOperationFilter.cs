using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HolaMundo.Filtro.v1.Filters
{
    public class AuthBasicRequirementOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Detecta atributos en el endpoint (Minimal APIs y Controllers)
            var hasAnonymous = context.ApiDescription.CustomAttributes().OfType<AllowAnonymousAttribute>().Any();
            //se verifica si el decorador esta para agregar el candado en el endpoint
            var hasAuthorize = context.ApiDescription.CustomAttributes().OfType<AutrorizacionBasicaFilter>().Any();

            if (hasAnonymous || !hasAuthorize) return;

            operation.Security ??= new List<OpenApiSecurityRequirement>();
            operation.Security.Add(new OpenApiSecurityRequirement
         {
             {
                 new OpenApiSecurityScheme {
                     Reference = new OpenApiReference {
                         Type = ReferenceType.SecurityScheme,
                         Id = "basic"
                     }
                 },
                 Array.Empty<string>()
             }
         });
        }
    }
}
