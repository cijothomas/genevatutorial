using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Trace;

public class Tutorial1
{
    private static readonly ActivitySource MyActivitySource = new("MyCompany.MyProduct.MyLibrary");

    public static void Start()
    {
        var tracerProvider = SetupTracing();

        using (var activity = MyActivitySource.StartActivity("activity-name"))
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
            .Build();

        return tracerProvider;
    }    
}