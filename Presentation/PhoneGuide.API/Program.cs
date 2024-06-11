using PhoneGuide.API.Extensions;
using PhoneGuide.Infrastructure;
using PhoneGuide.Infrastructure.Enums;
using PhoneGuide.Infrastructure.Services.HttpClientServices;
using PhoneGuide.Persistance;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceServices();
builder.Services.AddHttpClient().AddHttpClientService<ReportServiceHttpClient>();

builder.Services.AddCache(CachingType.InMemory);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var looger = new LoggerConfiguration()
.WriteTo.Console()
.WriteTo.File("logs/log.txt")
.WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"), "Logs", needAutoCreateTable: true)
.Enrich.FromLogContext()
.MinimumLevel.Information()
.CreateLogger();

builder.Host.UseSerilog(looger);

var app = builder.Build();

app.AddExceptionHandler(app.Services.GetRequiredService<ILogger<Program>>());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
