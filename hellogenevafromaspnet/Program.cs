using OpenTelemetry.Exporter.Geneva;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add OTel Tracing
builder.Services.AddOpenTelemetryTracing(builder => 
{
    builder.AddAspNetCoreInstrumentation();
    builder.AddHttpClientInstrumentation();
    builder.AddConsoleExporter();
    builder.AddGenevaTraceExporter(options => options.ConnectionString = "EtwSession=OpenTelemetry");
});

// Add OTel Logging
builder.Logging.AddOpenTelemetry(builder => 
{
    builder.AddConsoleExporter();
    builder.AddGenevaLogExporter(options => options.ConnectionString = "EtwSession=OpenTelemetry");
});

var app = builder.Build();

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
