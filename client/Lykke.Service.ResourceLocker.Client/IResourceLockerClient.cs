using Lykke.Service.ResourceLocker.Client.Models;
using System.Threading.Tasks;

namespace Lykke.Service.ResourceLocker.Client
{
    public interface IResourceLockerClient
    {
        Task<LockedResourceResponse> LockResource(LockedResourceRequest request);
        Task<bool> ReleaseResource(ReleaseResourceRequest request);
    }
}
