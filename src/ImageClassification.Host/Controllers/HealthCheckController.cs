using Microsoft.AspNetCore.Mvc;

namespace ImageClassification.Host.Controllers
{
    [ApiController]
    [Route("api/v1.0/healthcheck")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok(true);
        }
    }
}