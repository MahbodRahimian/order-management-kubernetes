var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("Financial")
    ?? throw new InvalidOperationException(
        "Connection string 'Financial' is not configured.");

builder.Services.AddSingleton(new FinancialDbConnection(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

public sealed class FinancialDbConnection
{
    public string ConnectionString { get; }

    public FinancialDbConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}