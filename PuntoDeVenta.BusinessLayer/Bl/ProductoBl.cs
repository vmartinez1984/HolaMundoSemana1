using PuntoDeVenta.Core.Dtos;
using PuntoDeVenta.Core.Interfaces;
using PuntoDeVenta.Repositories.Core.Entities;
using PuntoDeVenta.Repositories.Core.Interfaces;

namespace Productos.Api.BusinessLayer
{
    public class ProductoBl: IProductoBl
    {
        private readonly IProductoRepository _repository;

        public ProductoBl(IProductoRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<ProductoDto>> GetProductos()
        {
            List<ProductoDto> productos;
            var entities = await _repository.GetProductosAsync();
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
            var entity = new ProductoEntity
            {
                Encodedkey = productoDtoIn.Encodedkey,
                Nombre = productoDtoIn.Nombre,
                Descripcion = productoDtoIn.Descripcion,
                Precio = productoDtoIn.Precio,
                ImagenUrl = ""// productoDtoIn.ImagenUrl
            };
            await _repository.AgregarAsync(entity);
            IdDto idDto = new IdDto { Id = entity.Id, Mensaje = "Producto registrado" };
            return idDto;
        }

        public async Task<ProductoDto> GetProductoById(int id)
        {
            //var entity = await _appDbContext.Producto.FindAsync(id);
            //if (entity == null)
            //{
            //    return null;
            //}
            //ProductoDto productoDto = new ProductoDto
            //{
            //    Id = entity.Id,
            //    Encodedkey = entity.Encodedkey,
            //    Nombre = entity.Nombre,
            //    Descripcion = entity.Descripcion,
            //    Precio = entity.Precio
            //};
            //return productoDto;
            throw new NotImplementedException();
        }

    }
}
