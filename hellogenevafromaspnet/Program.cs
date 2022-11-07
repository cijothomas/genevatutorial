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
    builder.AddAspNetCoreInstrumentation((options) => options.Enrich
        = (activity, eventName, rawObject) =>
    {
        if (eventName.Equals("OnStartActivity"))
        {
            if (rawObject is HttpRequest httpRequest)
            {
                activity.SetTag("requestProtocol", httpRequest.Protocol);
            }
        }
        else if (eventName.Equals("OnStopActivity"))
        {
            if (rawObject is HttpResponse httpResponse)
            {
                activity.SetTag("responseLength", httpResponse.ContentLength);
            }
        }
    });
    builder.AddHttpClientInstrumentation((options) => options.Enrich
    = (activity, eventName, rawObject) =>
    {
        if (eventName.Equals("OnStartActivity"))
        {
            if (rawObject is HttpRequestMessage request)
            {
                activity.SetTag("requestVersion", request.Version);
            }
        }
        else if (eventName.Equals("OnStopActivity"))
        {
            // Console.WriteLine("On Stop");
            if (rawObject is HttpResponseMessage response)
            {
                activity.SetTag("responseVersion", response.Version);
            }
        }
        else if (eventName.Equals("OnException"))
        {
            if (rawObject is Exception exception)
            {
                activity.SetTag("stackTrace", exception.StackTrace);
            }
        }
    });
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
