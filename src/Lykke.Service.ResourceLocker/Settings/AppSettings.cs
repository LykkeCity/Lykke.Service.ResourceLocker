using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.ResourceLocker.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public ResourceLockerSettings ResourceLockerService { get; set; }
    }
}
