namespace HolaMundo.Middleware.v1.Middleware
{
    public class HolaMundoMiddleware
    {
        private readonly RequestDelegate _next;

        public HolaMundoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Lógica personalizada antes de llamar al siguiente middleware
            Console.WriteLine("Hola Mundo Middleware: Antes de la siguiente etapa");
            // Llamar al siguiente middleware en la cadena
            await _next(context);
            // Lógica personalizada después de llamar al siguiente middleware
            Console.WriteLine("Hola Mundo Middleware: Después de la siguiente etapa");
        }
    }
}
