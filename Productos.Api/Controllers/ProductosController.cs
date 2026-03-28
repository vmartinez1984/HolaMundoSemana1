using Microsoft.AspNetCore.Mvc;
using Productos.Api.Dtos;
using Productos.Api.Interfaces;

namespace Productos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoBl _productoBl;

        public ProductosController(IProductoBl productoBl)
        {
            this._productoBl = productoBl;
        }

        /// <summary>
        /// Obtener la lista de productos disponibles.
        /// </summary>
        /// <returns></returns>     
        /// <response code="200">Retorna la lista de productos.</response>
        [ProducesResponseType<List<ProductoDto>>(StatusCodes.Status200OK)]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ProductoDto> productos;

            productos = await _productoBl.GetProductos();

            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoDtoIn productoDtoIn)
        {
            IdDto idDto = await _productoBl.CreateProducto(productoDtoIn);             

            return Created($"Productos/{idDto.Id}", idDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ProductoDto productoDto = await _productoBl.GetProductoById(id);
            if (productoDto is null)
                return NotFound(new IdDto { Mensaje = "No se encontro el producto"});             

            return Ok(productoDto);
        }
    }
}
