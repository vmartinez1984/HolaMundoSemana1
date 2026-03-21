using Microsoft.AspNetCore.Mvc;
using Pizzas.Api.Dtos;
using Pizzas.Api.Services;

namespace Pizzas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        PizzasService _service;

        public PizzasController(PizzasService pizzasService)
        {
            _service = pizzasService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ProductoDto> pizzas = _service.ObtenerPizzas();

            return Ok(pizzas);
        }

        [HttpGet("Pollos")]
        public IActionResult ObtenerPollos()
        {
            return Ok("Pollos");
        }

    }
}
