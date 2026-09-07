using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Financial.API.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly FinancialDbConnection _database;

    public HealthController(FinancialDbConnection database)
    {
        _database = database;
    }

    [HttpGet]
    public IActionResult Health()
    {
        return Ok(new
        {
            status = "Healthy",
            service = "Financial"
        });
    }

    [HttpGet("db")]
    public async Task<IActionResult> DatabaseHealth()
    {
        try
        {
            await using var connection =
                new SqlConnection(_database.ConnectionString);

            await connection.OpenAsync();

            await using var command =
                new SqlCommand("SELECT 1", connection);

            var result = await command.ExecuteScalarAsync();

            return Ok(new
            {
                status = "Healthy",
                database = connection.Database,
                sqlResult = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                status = "Unhealthy",
                error = ex.Message
            });
        }
    }
}