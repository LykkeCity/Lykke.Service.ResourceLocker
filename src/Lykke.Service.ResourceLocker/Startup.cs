using JetBrains.Annotations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Lykke.Logs.Loggers.LykkeSlack;
using Lykke.Sdk;
using Lykke.Sdk.Health;
using Lykke.Sdk.Middleware;
using Lykke.Service.ResourceLocker.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Lykke.SettingsReader;
using StackExchange.Redis;
using Lykke.Service.ResourceLocker.Services;
using Lykke.Service.ResourceLocker.Core.Services;
using Newtonsoft.Json.Serialization;
using Lykke.Common.ApiLibrary.Swagger;
using Microsoft.AspNetCore.Mvc;
using Lykke.Logs;
using Lykke.Service.ResourceLocker.Modules;
using Lykke.Common.Log;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.ApiLibrary.Middleware;
using Lykke.Service.ResourceLocker.Models;
using Lykke.MonitoringServiceApiCaller;

namespace Lykke.Service.ResourceLocker
{
    [UsedImplicitly]
    public class Startup
    {
        private string _monitoringServiceUrl;
        public IHostingEnvironment Environment { get; }
        private IContainer ApplicationContainer { get; set; }
        public IConfigurationRoot Configuration { get; }
        private IHealthNotifier HealthNotifier { get; set; }
        private ILog Log { get; set; }

        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "ResourceLocker API",
            ApiVersion = "v1"
        };
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Environment = env;
        }
        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver =
                            new DefaultContractResolver();
                    });

                services.AddSwaggerGen(options =>
                {
                    options.DefaultLykkeConfiguration("v1", "ResourceLocker API");
                });
                services.Configure<MvcJsonOptions>(c =>
                {
                    // Serialize all properties to camelCase by default
                    c.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });


                var builder = new ContainerBuilder();
                var appSettings = Configuration.LoadSettings<AppSettings>();
                builder.RegisterInstance(appSettings).As<IReloadingManager<AppSettings>>();
                services.AddLykkeLogging(appSettings.Nested(x => x.ResourceLockerService.Db.LogsConnString),
                    "ResourceLockerLog",
                    appSettings.CurrentValue.SlackNotifications.AzureQueue.ConnectionString,
                    appSettings.CurrentValue.SlackNotifications.AzureQueue.QueueName
                );


                if (appSettings.CurrentValue.MonitoringServiceClient != null)
                    _monitoringServiceUrl = appSettings.CurrentValue.MonitoringServiceClient.MonitoringServiceUrl;

                builder.RegisterModule(new ServiceModule(appSettings));
                builder.Populate(services);
                ApplicationContainer = builder.Build();
                Log = ApplicationContainer.Resolve<ILogFactory>().CreateLog(this);
                HealthNotifier = ApplicationContainer.Resolve<IHealthNotifier>();
                return new AutofacServiceProvider(ApplicationContainer);
            }
            catch (Exception ex)
            {
                Log?.Critical(ex);
                throw;
            }
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseLykkeForwardedHeaders();
                app.UseLykkeMiddleware(ex => new OperationStatus { Error = true, Message = "Technical problem" });

                app.UseMvc();
                app.UseSwagger(c =>
                {
                    c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
                });
                app.UseSwaggerUI(x =>
                {
                    x.RoutePrefix = "swagger/ui";
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
                app.UseStaticFiles();
            }
            catch (Exception ex)
            {
                Log?.Critical(ex);
                throw;
            }
        }
    }
}
