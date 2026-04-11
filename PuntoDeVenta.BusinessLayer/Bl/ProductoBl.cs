using PuntoDeVenta.Core.Dtos;
using PuntoDeVenta.Core.Interfaces;
using PuntoDeVenta.Repositories.Core.Entities;
using PuntoDeVenta.Repositories.Core.Interfaces;

namespace Productos.Api.BusinessLayer
{
    public class ProductoBl : IProductoBl
    {
        private readonly IProductoRepository _repository;
        private readonly IAlmacenDeArchivos _almacenDeArchivos;

        public ProductoBl(IProductoRepository repository, IAlmacenDeArchivos almacenDeArchivos)
        {
            _repository = repository;
            _almacenDeArchivos = almacenDeArchivos;
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
            await AgregarArchivo(productoDtoIn);
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

        private async Task AgregarArchivo(ProductoDtoIn productoDtoIn)
        {
            if(productoDtoIn.FormFile is not null)
            {
                string nombreDelArchivo = $"{productoDtoIn.Encodedkey}.png";
                string ruta = await _almacenDeArchivos.AgregarArchivoAsync(nombreDelArchivo, productoDtoIn.FormFile);
            }
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

        public async Task<ProductoDto> GetProductoByEncodedKey(Guid encodedKey)
        {
            var entity = await _repository.GetByEncodeyKey(encodedKey);
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

        public async Task<byte[]> ObtenerImagenAsync(Guid encodedKey)
        {
            var bytes = await _almacenDeArchivos.ObtenerArchivoAsync($"{encodedKey}.png");

            return bytes;
        }
    }
}
