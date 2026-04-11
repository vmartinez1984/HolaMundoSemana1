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
        string RutaBase = "C:\\Users\\ahal_\\source\\repos\\HolaMundoSemana1\\Productos.Api\\wwwroot\\";

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
            if (productoDtoIn.FormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await productoDtoIn.FormFile.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var ruta = RutaBase + productoDtoIn.Encodedkey +"."+ productoDtoIn.FormFile.ContentType.Split("/")[1];
                    await System.IO.File.WriteAllBytesAsync(ruta, contenido);
                }
            }
            IdDto idDto = await _productoBl.CreateProducto(productoDtoIn);             

            return Created($"Productos/{idDto.Id}", idDto);
        }

        [HttpGet("Imagenes/{encodekey}")]
        public async Task<IActionResult> ObtenerImagen(string encodekey)
        {
           var bytes = System.IO.File.ReadAllBytes(RutaBase + encodekey + ".png");

           return File(bytes, "image/jpeg");
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
