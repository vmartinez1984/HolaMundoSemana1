using HolaMundo.ConsumoDeServicios.v1.Dtos;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HolaMundo.ConsumoDeServicios.v1.Services
{
    public class CodigoPostalService
    {
        public async Task<List<EstadoDto>> ObtenerEstados()
        {
            List<EstadoDto> estados;
            var client = new HttpClient();
            var url = "https://utilidades.vmartinez84.xyz/api/CodigosPostales/Estados";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("accept", "application/json");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                estados = JsonSerializer.Deserialize<List<EstadoDto>>(await  response.Content.ReadAsStringAsync());

                return estados;
            }
            else
            {
                return new List<EstadoDto>();
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<CodigoPostalDto> ObtenerCodigoPostalAleatorio()
        {
            CodigoPostalDto codigoPostalDto;
            var client = new HttpClient();
            var url = "https://utilidades.vmartinez84.xyz/api/CodigosPostales/Aleatorio";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("accept", "application/json");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                codigoPostalDto = JsonSerializer.Deserialize<CodigoPostalDto>(await response.Content.ReadAsStringAsync());

                return codigoPostalDto;
            }
            else
            {
                return null;
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
