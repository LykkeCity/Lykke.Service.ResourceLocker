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
        //private readonly IDistributedLockService _resourceLockService;
        public ResourceLockService(IDistributedLockService resourceLockService)
        {
            //_resourceLockService = resourceLockService ?? throw new ArgumentNullException(nameof(resourceLockService));
        }

        public void Block(ILockedResource lockedResource)
        {
            //_resourceLockService.TryAcquireLockAsync(lockedResource.ResourceId, lockedResource.Owner, lockedResource.ExpirationTime);
        }

        public Task<ILockedResource> GetAsync(string blockId)
        {
            throw new System.NotImplementedException();
        }
    }
}
