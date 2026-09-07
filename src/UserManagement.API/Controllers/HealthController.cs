using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace UserManagement.API.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly UserManagementDbConnection _db;

    public HealthController(UserManagementDbConnection db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "Healthy",
            service = "UserManagement.API"
        });
    }

    [HttpGet("db")]
    public async Task<IActionResult> Database()
    {
        await using var connection = new SqlConnection(_db.ConnectionString);

        await connection.OpenAsync();

        await using var command = new SqlCommand("SELECT 1", connection);

        var result = await command.ExecuteScalarAsync();

        return Ok(new
        {
            status = "Healthy",
            database = "CS.UserManagement",
            sqlResult = result
        });
    }
}