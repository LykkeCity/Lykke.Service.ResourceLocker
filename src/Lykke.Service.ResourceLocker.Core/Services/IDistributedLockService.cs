using Lykke.Service.ResourceLocker.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Lykke.Service.ResourceLocker.Core.Services
{
    public interface IDistributedLockService
    {
        Task<bool> TryAcquireLockAsync(ILockedResourceRequest request, DateTime expiration);

        Task<bool> ReleaseLockAsync(string key, string ownerId);
        string GetCacheKey(string serviceName, string resourceId);
        Task<string> GetBlockerOwner(string key);
    }
}
