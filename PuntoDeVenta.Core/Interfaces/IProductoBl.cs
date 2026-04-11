using PuntoDeVenta.Core.Dtos;

namespace PuntoDeVenta.Core.Interfaces
{
    public interface IProductoBl
    {
        Task<List<ProductoDto>> GetProductos();

        Task<ProductoDto> GetProductoById(int id);

        Task<IdDto> CreateProducto(ProductoDtoIn productoDtoIn);

        Task<ProductoDto> GetProductoByEncodedKey(Guid encodedKey);
        Task<byte[]> ObtenerImagenAsync(Guid encodedKey);
    }
}
