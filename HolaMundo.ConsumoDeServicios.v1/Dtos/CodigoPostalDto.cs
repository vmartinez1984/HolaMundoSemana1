using System.Text.Json.Serialization;

namespace HolaMundo.ConsumoDeServicios.v1.Dtos
{
    public class CodigoPostalDto
    {
        [JsonPropertyName("codigoPostal")]
        public string CodigoPostal { get; set; }

        [JsonPropertyName("alcaldiaId")]
        public int AlcaldiaId { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("estadoId")]
        public int EstadoId { get; set; }

        [JsonPropertyName("alcaldia")]
        public string Alcaldia { get; set; }

        [JsonPropertyName("tipoDeAsentamiento")]
        public string TipoDeAsentamiento { get; set; }

        [JsonPropertyName("asentamiento")]
        public string Asentamiento { get; set; }
    }
}
