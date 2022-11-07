using System.Diagnostics;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter.Geneva;

public class Tutorial4
{
    private static readonly ActivitySource MyActivitySource = new("MyCompany.MyProduct.MyLibrary");

    public static void Start()
    {
        Console.WriteLine("Welcome to Tutorial1 !");

        var tracerProvider = SetupTracing();
        var loggerFactory = SetupLogging();
        var logger = loggerFactory.CreateLogger("main");

        using (var activity = MyActivitySource.StartActivity("activity-name"))
        {
            activity?.SetTag("intKey", 200);
            activity?.SetTag("stringKey", "StringValue");
            logger.LogError("Request from {userid} received. status {status}", "awesome_geneva_user", 200);

            AppCode();
        }

        // App exits.. Make sure to Dispose!!
        tracerProvider.Dispose();
        loggerFactory.Dispose();
    }

    private static void AppCode()
    {
        using (var activity = MyActivitySource.StartActivity("activity-name-child"))
        {
            activity?.SetTag("intKey", 200);
            activity?.SetTag("stringKey", "StringValue");

            ChildAppCode();
        }
    }

    private static void ChildAppCode()
    {

    }

    private static TracerProvider SetupTracing()
    {
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("MyCompany.MyProduct.*")
            .AddConsoleExporter()
            .AddGenevaTraceExporter(options => options.ConnectionString = "EtwSession=OpenTelemetry")
            .Build();

        return tracerProvider;
    }

    private static ILoggerFactory SetupLogging()
    {
        var loggerFactory = LoggerFactory.Create(builder => builder
        .AddOpenTelemetry(loggerOptions =>
        {
            loggerOptions.AddConsoleExporter();
            loggerOptions.AddGenevaLogExporter(exporterOptions =>
            {
                exporterOptions.ConnectionString = "EtwSession=OpenTelemetry";
                exporterOptions.ExceptionStackExportMode = ExceptionStackExportMode.ExportAsString;
            });
        }));

        return loggerFactory;
    }   
}