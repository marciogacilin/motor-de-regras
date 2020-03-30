using Microsoft.AspNetCore.Mvc;

namespace MotorDeRegras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        /// <summary>
        /// Teste de descrição do método controlador
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>Hellow World</returns>
        /// <response code="200">Retorna um hellow world</response>
        /// <response code="400">Erro retornado</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("Helow World!");
        }
    }
}