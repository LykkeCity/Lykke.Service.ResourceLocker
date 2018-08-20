using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.ResourceLocker.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class ResourceLockerSettings
    {
        public DbSettings Db { get; set; }
        public CacheSettings CacheSettings { get; set; }
    }
}
