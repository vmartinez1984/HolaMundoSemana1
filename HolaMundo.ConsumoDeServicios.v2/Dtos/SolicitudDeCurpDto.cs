using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HolaMundo.ConsumoDeServicios.v1.Dtos
{
    public class SolicitudDeCurpDto
    {
        [Required]
        [MaxLength(255)]
        [JsonPropertyName("nombres")]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(255)]
        [JsonPropertyName("primerApellido")]
        public string PrimerApellido { get; set; }


        [JsonPropertyName("segundoApellido")]
        public string SegundoApellido { get; set; }

        [Required]        
        [JsonPropertyName("fechaDeNacimiento")]
        public DateOnly FechaDeNacimiento { get; set; }

        [Required]        
        [JsonPropertyName("sexo")]
        public string Sexo { get; set; }

        [Required]        
        [JsonPropertyName("estado")]
        public string Estado { get; set; }
    }
}
