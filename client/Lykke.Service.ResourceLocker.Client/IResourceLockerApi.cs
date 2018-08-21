using JetBrains.Annotations;
using Lykke.Service.ResourceLocker.Client.Models;
using Refit;
using System.Threading.Tasks;

namespace Lykke.Service.ResourceLocker.Client
{
    public interface IResourceLockerApi
    {
        [Post("/api/lock/lockresource")]
        Task<LockedResourceResponse> LockResourceAsync([Body] LockedResourceRequest request);
        [Post("/api/lock/releaseresource")]
        Task<bool> ReleaseResourceAsync([Body] ReleaseResourceRequest request);
    }
}
