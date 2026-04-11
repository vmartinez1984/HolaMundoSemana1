using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Core.Dtos
{
    public class ProductoDtoIn
    {
        public Guid Encodedkey { get; set; } = Guid.NewGuid();

        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(200)]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [Range(25, 350)]
        public decimal Precio { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
