using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using DataAccess;
using LokiLoggingProvider.Options;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Services.Interfaces;
using Services.Realization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SongsDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

builder.Services.AddScoped<ISongService, SongService>();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
builder.Services.AddMetrics();
builder.Services.AddMetricsTrackingMiddleware();

builder.Host
    .UseMetricsWebTracking()
    .UseMetrics(options => { options.EndpointOptions = endpointsOptions =>
    {
        endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
        endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
        endpointsOptions.EnvironmentInfoEndpointEnabled = false;
    };
});


builder.Logging.AddLoki(loggerOptions =>
{
    loggerOptions.Client = PushClient.Grpc;
    loggerOptions.StaticLabels.JobName = "Domain";
});

const string serviceName = "SongsService";
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(serviceName))
    .WithTracing(traceProviderBuilder =>
        traceProviderBuilder
            .AddSource(serviceName)
            .AddAspNetCoreInstrumentation(options => options.RecordException = true)
            .AddOtlpExporter()
        );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
app.UseEnvInfoEndpoint();
*/

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();