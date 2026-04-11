using Microsoft.AspNetCore.Http;

namespace PuntoDeVenta.Core.Interfaces
{
    public interface IAlmacenDeArchivos
    {
        Task<string> AgregarArchivoAsync(string nombreDelArchivo, IFormFile formFile);

        Task<byte[]> ObtenerArchivoAsync(string ruta);

        Task BorrarArchivoAsync(string ruta);
    }
}
