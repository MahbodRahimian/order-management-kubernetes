using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("Financial");

builder.Services.AddSingleton(new FinancialDbConnection(connectionString!));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Urls.Add("http://0.0.0.0:5000");

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