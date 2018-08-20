using Lykke.HttpClientGenerator;

namespace Lykke.Service.ResourceLocker.Client
{
    /// <summary>
    /// ResourceLocker API aggregating interface.
    /// </summary>
    public class ResourceLockerClient : IResourceLockerClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Inerface to ResourceLocker Api.</summary>
        public IResourceLockerApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public ResourceLockerClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<IResourceLockerApi>();
        }
    }
}
