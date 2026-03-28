using HolaMundo.ConsumoDeServicios.v1.Dtos;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace HolaMundo.ConsumoDeServicios.v1.Services
{
    public class RenapoService
    {
        public async Task<CurpDto> ObtenerCurpAsync(SolicitudDeCurpDto solicitud)
        {
            CurpDto curp;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://utilidades.vmartinez84.xyz/api/Curp");
            request.Headers.Add("accept", "application/json");
            var body = JsonSerializer.Serialize(solicitud, new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All), });
            var content = new StringContent(body, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                curp = JsonSerializer.Deserialize<CurpDto>(await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return curp;
            }
            else
            {
                return null;
            }

        }
    }
}
