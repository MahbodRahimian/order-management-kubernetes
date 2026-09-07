var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("IDP")
    ?? throw new InvalidOperationException(
        "Connection string 'IDP' is not configured.");

builder.Services.AddSingleton(new IDPDbConnection(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

public sealed class IDPDbConnection
{
    public string ConnectionString { get; }

    public IDPDbConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}