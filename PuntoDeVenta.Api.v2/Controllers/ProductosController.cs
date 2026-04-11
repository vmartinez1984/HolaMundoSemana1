using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Core.Dtos;
using PuntoDeVenta.Core.Interfaces;

namespace PuntoDeVenta.Api.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoBl productoBl;

        public ProductosController(IProductoBl productoBl)
        {
            this.productoBl = productoBl;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await productoBl.GetProductos();
            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto(ProductoDtoIn productoDtoIn)
        {
            ProductoDto productoDto = await productoBl.GetProductoByEncodedKey(productoDtoIn.Encodedkey);
            if(productoDto is not null)
            {
                return StatusCode(StatusCodes.Status208AlreadyReported, new IdDto { Id = productoDto.Id });
            }
            var idDto = await productoBl.CreateProducto(productoDtoIn);
            return Created(string.Empty, idDto);
        }

        [HttpGet("Imagenes/{encodedKey}")]
        public async Task<IActionResult> GetImagen(Guid encodedKey)
        {
            var bytes = await productoBl.ObtenerImagenAsync(encodedKey);

            return File(bytes, "image/png");
        }
    }
}
