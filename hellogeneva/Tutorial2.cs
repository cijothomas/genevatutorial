using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter.Geneva;

public class Tutorial2
{
    private static readonly ActivitySource MyActivitySource = new("MyCompany.MyProduct.MyLibrary");

    public static void Start()
    {
        Console.WriteLine("Welcome to Tutorial1 !");

        var tracerProvider = SetupTracing();

        using (var activity = MyActivitySource.StartActivity("myactivity"))
        {
            activity?.SetTag("intKey", 200);
            activity?.SetTag("stringKey", "StringValue");

            AppCode();
        }
    }

    private static void AppCode()
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
}