using JetBrains.Annotations;

namespace Lykke.Service.ResourceLocker.Client
{
    /// <summary>
    /// ResourceLocker client interface.
    /// </summary>
    [PublicAPI]
    public interface IResourceLockerClient
    {
        /// <summary>Application Api interface</summary>
        IResourceLockerApi Api { get; }
    }
}
