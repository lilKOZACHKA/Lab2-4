using Microsoft.AspNetCore.Mvc;

namespace SimpsonsIntegrationAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class IntegrationController : ControllerBase
    {
        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] IntegrationRequest request)
        {
            try
            {
                // Проверка входных данных
                if (request.N % 2 != 0)
                    return BadRequest("N must be even.");

                if (request.A >= request.B)
                    return BadRequest("A must be less than B.");

                // Парсинг функции
                var function = SimpsonsSolver.ParseFunction(request.Function);

                // Вычисление интеграла
                double result = SimpsonsSolver.Solve(request.A, request.B, request.N, function);

                // Формирование ответа
                return Ok(new IntegrationResponse { Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}