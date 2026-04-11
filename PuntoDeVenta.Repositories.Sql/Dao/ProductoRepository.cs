using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Repositories.Core.Entities;
using PuntoDeVenta.Repositories.Core.Interfaces;
using PuntoDeVenta.Repositories.Sql.Contexts;

namespace PuntoDeVenta.Repositories.Sql.Dao
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AgregarAsync(ProductoEntity producto)
        {
            await _dbContext.Producto.AddAsync(producto);
            await _dbContext.SaveChangesAsync();

            return producto.Id;
        }

        public async Task<List<ProductoEntity>> GetProductosAsync() => await _dbContext.Producto.ToListAsync();        
        //{ 
        //   List<ProductoEntity> productos = await _dbContext.Producto.ToListAsync();

        //    return productos;
        //}

        public async Task<ProductoEntity> GetByEncodeyKey(Guid encodedKey)
        {
            return await _dbContext.Producto.FirstOrDefaultAsync(p => p.Encodedkey == encodedKey);
        }
    }
        
}