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
        public async Task<IActionResult> CreateProducto([FromBody] ProductoDtoIn productoDtoIn)
        {
            var idDto = await productoBl.CreateProducto(productoDtoIn);
            return Created(string.Empty, idDto);
        }
    }
}
