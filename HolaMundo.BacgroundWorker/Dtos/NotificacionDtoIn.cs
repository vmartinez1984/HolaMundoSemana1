using System.ComponentModel.DataAnnotations;

namespace HolaMundo.BacgroundWorker.Dtos
{
    public class NotificacionDtoIn
    {
        [Required(ErrorMessage = "El campo 'Correo' es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo 'Correo' debe ser una dirección de correo válida.")]
        public string Correo { get; set; }
    }
}
