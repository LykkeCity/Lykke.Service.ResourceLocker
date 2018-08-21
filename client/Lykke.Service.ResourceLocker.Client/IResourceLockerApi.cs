using Lykke.Service.ResourceLocker.Client.Models;
using Refit;
using System.Threading.Tasks;

namespace Lykke.Service.ResourceLocker.Client
{
    internal interface IResourceLockerApi
    {
        /// <summary>
        /// Lock resource
        /// </summary>
        /// <param name="request">Request model for lock resource</param>
        /// <returns></returns>
        [Post("/api/lock/lockresource")]
        Task<LockedResourceResponse> LockResourceAsync([Body] LockedResourceRequest request);
        /// <summary>
        /// Release resource
        /// </summary>
        /// <param name="request">Release model for locked resource</param>
        /// <returns></returns>
        [Post("/api/lock/releaseresource")]
        Task<bool> ReleaseResourceAsync([Body] ReleaseResourceRequest request);
    }
}
