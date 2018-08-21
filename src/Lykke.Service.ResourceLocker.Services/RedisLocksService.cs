using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.ResourceLocker.Core.Domain;
using Lykke.Service.ResourceLocker.Core.Services;
using StackExchange.Redis;

namespace Lykke.Service.ResourceLocker.Services
{
    public class RedisLocksService : IDistributedLockService
    {
        private readonly string _keyPattern;
        private readonly IDatabase _database;

        public RedisLocksService(
            [NotNull] string keyPattern,
            [NotNull] IConnectionMultiplexer connectionMultiplexer)
        {
            _keyPattern = keyPattern ?? throw new ArgumentNullException(nameof(keyPattern));
            _database = connectionMultiplexer.GetDatabase() ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
        }

        public Task<bool> TryAcquireLockAsync(ILockedResourceRequest request, DateTime expiration)
        {
            TimeSpan expiresIn = expiration - DateTime.UtcNow;
            return _database.LockTakeAsync(GetCacheKey(request.ServiceName, request.ResourceId, request.Owner), request.ResourceId, expiresIn);
        }

        public Task<bool> ReleaseLockAsync(string key, string resourceId)
        {
            return _database.LockReleaseAsync(key, resourceId);
        }

        public string GetCacheKey(string serviceName, string resourceId, string owner)
        {
            return string.Format(_keyPattern, serviceName, resourceId, owner);
        }
    }
}
