using Microsoft.Extensions.DependencyInjection;

namespace HolaMundo.Notificaciones
{
    public static class Extensor
    {
        public static void AgregarNotificacion(this IServiceCollection services)
        {
            services.AddScoped<INotificacion, Notificacion>();
        }
    }
}
