using Microsoft.AspNetCore.Http;
using PuntoDeVenta.Core.Interfaces;

namespace AlmacenDeArchivos.Local
{
    public class Almacen : IAlmacenDeArchivos
    {
        string RutaBase = "C:\\Users\\ahal_\\source\\repos\\HolaMundoSemana1\\Productos.Api\\wwwroot\\";

        public async Task<string> AgregarArchivoAsync(string nombreDelArchivo, IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                var contenido = memoryStream.ToArray();
                var ruta = RutaBase + nombreDelArchivo;
                await File.WriteAllBytesAsync(ruta, contenido);
            }

            return nombreDelArchivo;
        }

        public Task BorrarArchivoAsync(string ruta)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> ObtenerArchivoAsync(string ruta)
        {
            var bytes = File.ReadAllBytes(RutaBase + ruta);

            return bytes;
        }
    }
}
