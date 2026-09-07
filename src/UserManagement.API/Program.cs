var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("UserManagement")
    ?? throw new InvalidOperationException(
        "Connection string 'UserManagement' is not configured.");

builder.Services.AddSingleton(new UserManagementDbConnection(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

public sealed class UserManagementDbConnection
{
    public string ConnectionString { get; }

    public UserManagementDbConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}