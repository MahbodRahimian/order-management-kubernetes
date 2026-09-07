using Microsoft.AspNetCore.Mvc;

namespace Silo.API.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Health()
    {
        return Ok(new
        {
            status = "Healthy",
            service = "Silo"
        });
    }
}