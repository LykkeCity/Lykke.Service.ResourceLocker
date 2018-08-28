using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.ResourceLocker.Core.Domain;
using Lykke.Service.ResourceLocker.Core.Services;

namespace Lykke.Service.ResourceLocker.Services
{
    [UsedImplicitly]
    public class ResourceLockService : IResourceLockService
    {
        private readonly IDistributedLockService _resourceLockService;
        public ResourceLockService(IDistributedLockService resourceLockService)
        {
            _resourceLockService = resourceLockService ?? throw new ArgumentNullException(nameof(resourceLockService));
        }

        public async Task<ILockedResourceResponse> Block(ILockedResourceRequest lockedResource)
        {
            var key = _resourceLockService.GetCacheKey(lockedResource.ServiceName, lockedResource.ResourceId);
            var locked = new LockedResourceResponse
            {
                Key = key,
                IsLocked = await _resourceLockService.TryAcquireLockAsync(lockedResource, lockedResource.ExpirationTime),
                Owner = await _resourceLockService.GetBlockerOwner(key)
            };
            return locked;
        }

        public async Task<bool> Release(IReleaseResourceRequest lockedResource)
        {
            return await _resourceLockService.ReleaseLockAsync(lockedResource.Key, lockedResource.Owner);
        }
    }
}
