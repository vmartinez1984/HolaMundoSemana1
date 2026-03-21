using Microsoft.EntityFrameworkCore;
using Productos.Api.Contexts;
using Productos.Api.Dtos;
using Productos.Api.Interfaces;

namespace Productos.Api.BusinessLayer
{
    public class ProductoBl: IProductoBl
    {
        private readonly AppDbContext _appDbContext;

        public ProductoBl(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<List<ProductoDto>> GetProductos()
        {
            List<ProductoDto> productos;
            var entities = await _appDbContext.Producto.ToListAsync();
            productos = entities.Select(e => new ProductoDto
            {
                Id = e.Id,
                Encodedkey = e.Encodedkey,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Precio = e.Precio
            }).ToList();
            return productos;
        }

        public async Task<IdDto> CreateProducto(ProductoDtoIn productoDtoIn)
        {
            var entity = new Entities.ProductoEntity
            {
                Encodedkey = productoDtoIn.Encodedkey,
                Nombre = productoDtoIn.Nombre,
                Descripcion = productoDtoIn.Descripcion,
                Precio = productoDtoIn.Precio,
                ImagenUrl = ""// productoDtoIn.ImagenUrl
            };
            _appDbContext.Producto.Add(entity);
            await _appDbContext.SaveChangesAsync();
            IdDto idDto = new IdDto { Id = entity.Id, Mensaje = "Producto registrado" };
            return idDto;
        }

        public async Task<ProductoDto> GetProductoById(int id)
        {
            var entity = await _appDbContext.Producto.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            ProductoDto productoDto = new ProductoDto
            {
                Id = entity.Id,
                Encodedkey = entity.Encodedkey,
                Nombre = entity.Nombre,
                Descripcion = entity.Descripcion,
                Precio = entity.Precio
            };
            return productoDto;
        }

    }
}
