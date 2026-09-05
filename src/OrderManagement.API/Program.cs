var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("OrderManagement")
    ?? throw new InvalidOperationException(
        "Connection string 'OrderManagement' is not configured.");

builder.Services.AddSingleton(new OrderManagementDbConnection(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

public sealed class OrderManagementDbConnection
{
    public string ConnectionString { get; }

    public OrderManagementDbConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}