using System.Text.Json.Serialization;

namespace HolaMundo.ConsumoDeServicios.v1.Dtos
{
    public class EstadoDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName ("nombre")]
        public string Nombre { get; set; }
    }
}
