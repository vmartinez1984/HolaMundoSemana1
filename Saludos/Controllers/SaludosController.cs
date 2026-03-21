using Microsoft.AspNetCore.Mvc;
using Saludos.Dtos;

namespace Saludos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaludosController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola Mundo");
        }

        [HttpGet("{saludo}")]
        public IActionResult Get(string saludo)
        {
            return Ok($"Hola {saludo}");
        }

        /// <summary>
        /// Hola mundo
        /// </summary>
        /// <returns></returns>
        /// <response code="200">IdDto</response>
        [ProducesResponseType(typeof(IdDto), StatusCodes.Status200OK)]
        [Produces("application/json")]
        [HttpPost]
        public IActionResult Post([FromBody] SaludoDtoIn saludo)
        {
            //var json = new { Mensaje = $"Hola {saludo.Saludo}" };
            //return Ok(json);

            IdDto idDto = new IdDto
            {
                Id = Guid.NewGuid().ToString(),
                Mensaje = $"Hola {saludo.Saludo}"
            };

            return Ok(idDto);
        }

        /// <summary>
        /// Regresa un error 500 Internal Server Error con un ProblemDetails personalizado
        /// </summary>
        /// <returns></returns>
        /// <response code="500"></response>
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                throw new Exception("Este es un error");
            }
            catch (Exception)
            {
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Title = "Error",
                    Detail = "Ocurrió un error al procesar la solicitud",
                    Status = StatusCodes.Status500InternalServerError
                };
                return StatusCode(StatusCodes.Status500InternalServerError, problemDetails);
            }
        }

    }
}
