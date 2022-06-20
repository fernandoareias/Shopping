using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Exceptions;
using Elastic.Apm.SerilogEnricher;
using Elastic.CommonSchema.Serilog;

namespace Shopping.Core.WebAPI.Monitoramento
{
    public static class SerilogExtensions
    {
        public static void AddSerilog(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
             .ReadFrom.Configuration(configuration)
             .Enrich.FromLogContext()
             .Enrich.WithMachineName()
             .Enrich.WithEnvironmentUserName()
             .Enrich.WithExceptionDetails()
             .Enrich.WithElasticApmCorrelationInfo()
             .Enrich.WithProperty("ApplicationName", $"API Elastic APM - {configuration.GetSection("DOTNET_ENVIRONMENT")?.Value}")
             .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticsearchSettings:uri"]))
             {
                 CustomFormatter = new EcsTextFormatter(),
                 AutoRegisterTemplate = true,
                 IndexFormat = "indexlogs",
                 ModifyConnectionSettings = x => x.BasicAuthentication(configuration["ElasticsearchSettings:username"], configuration["ElasticsearchSettings:password"])
             })
             .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
             .CreateLogger();
        }
    }
}
