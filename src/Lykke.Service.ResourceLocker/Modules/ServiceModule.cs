using Autofac;
using Lykke.Sdk.Health;
using Lykke.Service.ResourceLocker.Core.Services;
using Lykke.Service.ResourceLocker.Services;
using Lykke.Service.ResourceLocker.Settings;
using Lykke.SettingsReader;
using StackExchange.Redis;

namespace Lykke.Service.ResourceLocker.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Do not register entire settings in container, pass necessary settings to services which requires them
            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.Register(c => ConnectionMultiplexer.Connect(c.Resolve<IReloadingManager<AppSettings>>().Nested(n => n.ResourceLockerService.CacheSettings.RedisConfiguration).CurrentValue))
                .As<IConnectionMultiplexer>();

            builder.RegisterType<RedisLocksService>()
                .As<IDistributedLockService>();

            builder.RegisterType<ResourceLockService>()
                .As<IResourceLockService>();
        }
    }
}
