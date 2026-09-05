using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.API.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "Healthy",
            service = "OrderManagement.API"
        });
    }
}