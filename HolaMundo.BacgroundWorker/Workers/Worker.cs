using HolaMundo.Notificaciones;

namespace HolaMundo.BacgroundWorker.Workers
{
    public class Worker : IHostedService, IDisposable
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }


        public void Dispose()
        {
            _timer.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            //_logger.LogInformation("Enviando correo...");
            //using (var scope = _serviceScopeFactory.CreateScope())
            //{
            //    var notificacion = scope.ServiceProvider.GetRequiredService<INotificacion>();
            //    notificacion.EnviarAsync("ahal_tocob@hotmail.com");
            //    _logger.LogInformation("Correo enviado");
            //}
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
