using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.ResourceLocker.Client 
{
    /// <summary>
    /// ResourceLocker client settings.
    /// </summary>
    public class ResourceLockerServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
