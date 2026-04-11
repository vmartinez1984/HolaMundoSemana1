using PuntoDeVenta.Repositories.Core.Entities;

namespace PuntoDeVenta.Repositories.Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<ProductoEntity>> GetProductosAsync();

        Task<int> AgregarAsync(ProductoEntity producto);

        Task<ProductoEntity> GetByEncodeyKey(Guid encodedKey);
    }
}
