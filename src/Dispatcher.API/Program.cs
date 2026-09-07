var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("Dispatcher")
    ?? throw new InvalidOperationException(
        "Connection string 'Dispatcher' is not configured.");

builder.Services.AddSingleton(new DispatcherDbConnection(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

public sealed class DispatcherDbConnection
{
    public string ConnectionString { get; }

    public DispatcherDbConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}