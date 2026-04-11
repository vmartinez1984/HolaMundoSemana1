using HolaMundo.BacgroundWorker.Dtos;
using HolaMundo.Notificaciones;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.BacgroundWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacion _notificacion;

        public NotificacionesController(INotificacion notificacion)
        {
            _notificacion = notificacion;
        }

        [HttpGet]
        public async Task<IActionResult> EnviarNotificacion(string correoDestino)
        {
            await _notificacion.EnviarConGmail(correoDestino);

            //Aqui enviaremos datos de loq ue ocurrio
            return Ok();
        }

        [HttpPost("Registros")]
        public async Task<IActionResult> SimularRegistroYNotificacion([FromBody] NotificacionDtoIn notificacionDto)
        {
            _notificacion.EnviarAsync(notificacionDto.Correo);

            //Aqui enviaremos datos de lo que ocurrio
            return Ok(new { EncodedKey= Guid.NewGuid(), Mensaje= "Registro en Proceso" });
        }
    }
}
