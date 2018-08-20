using System;
using System.Threading.Tasks;

namespace Lykke.Service.ResourceLocker.Core.Services
{
    public interface IDistributedLockService
    {
        Task<bool> TryAcquireLockAsync(string key, string token, DateTime expiration);

        Task<bool> ReleaseLockAsync(string key, string token);
    }
}
