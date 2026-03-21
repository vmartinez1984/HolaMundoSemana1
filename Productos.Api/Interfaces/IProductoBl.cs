using Productos.Api.Dtos;

namespace Productos.Api.Interfaces
{
    public interface IProductoBl
    {
        Task<List<ProductoDto>> GetProductos();

        Task<ProductoDto> GetProductoById(int id);

        Task<IdDto> CreateProducto(ProductoDtoIn productoDtoIn);
    }
}
