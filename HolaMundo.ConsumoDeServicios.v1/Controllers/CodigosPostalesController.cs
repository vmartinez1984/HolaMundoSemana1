using HolaMundo.ConsumoDeServicios.v1.Dtos;
using HolaMundo.ConsumoDeServicios.v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.ConsumoDeServicios.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigosPostalesController : ControllerBase
    {
        private readonly CodigoPostalService service;

        public CodigosPostalesController(CodigoPostalService service)
        {
            this.service = service;
        }

        [HttpGet("Estados")]
        public async Task<IActionResult> Get() {
            List<EstadoDto> estados;

            estados = await service.ObtenerEstados();

            return Ok(estados);
        }

        [HttpGet("Aleatorio")]
        public async Task<IActionResult> Aleatorio() { 
            CodigoPostalDto codigoPostalDto = await service.ObtenerCodigoPostalAleatorio();

            return Ok(codigoPostalDto);
        }
    }
}
