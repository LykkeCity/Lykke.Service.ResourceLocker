using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.ResourceLocker.Settings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
    }
}
