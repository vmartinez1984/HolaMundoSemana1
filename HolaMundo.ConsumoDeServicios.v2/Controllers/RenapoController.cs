using HolaMundo.ConsumoDeServicios.v1.Dtos;
using HolaMundo.ConsumoDeServicios.v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.ConsumoDeServicios.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenapoController : ControllerBase
    {
        private readonly RenapoService service;

        public RenapoController(RenapoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            SolicitudDeCurpDto solicitud = new SolicitudDeCurpDto
            {
                Estado = "Hidalgo",
                FechaDeNacimiento = new DateOnly(1984, 12, 05),
                Nombres = "Vítor",
                PrimerApellido = "Martínez",
                SegundoApellido = "Bravo",
                Sexo = "h"
            };
            CurpDto curpDto = await service.ObtenerCurpAsync(solicitud);

            return Ok(curpDto);
        }
    }
}