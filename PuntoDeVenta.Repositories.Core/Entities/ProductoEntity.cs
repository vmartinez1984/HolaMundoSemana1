using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Repositories.Core.Entities
{
    public class ProductoEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid Encodedkey { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(200)]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [MaxLength(1000)]
        public string ImagenUrl { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
