using System.ComponentModel.DataAnnotations;

namespace Productos.Api.Dtos
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

        //[MaxLength(1000)]
        //public string ImagenUrl { get; set; }
    }
}
