var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("Silo")
    ?? throw new InvalidOperationException(
        "Connection string 'Silo' is not configured.");

builder.Services.AddSingleton(new SiloDbConnection(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

public sealed class SiloDbConnection
{
    public string ConnectionString { get; }

    public SiloDbConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}