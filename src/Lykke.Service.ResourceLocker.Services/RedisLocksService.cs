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
            var isexist = _database.KeyExists(GetCacheKey(request.ServiceName, request.ResourceId));
            if (isexist)
                return Task.FromResult(false);
            return _database.LockTakeAsync(GetCacheKey(request.ServiceName, request.ResourceId), request.Owner, expiresIn);
        }

        public async Task<string> GetBlockerOwner(string key)
        {
            var value = await _database.LockQueryAsync(key);
            return value.ToString();
        }

        public Task<bool> ReleaseLockAsync(string key, string ownerId)
        {
            return _database.LockReleaseAsync(key, ownerId);
        }

        public string GetCacheKey(string serviceName, string resourceId)
        {
            return string.Format(_keyPattern, serviceName, resourceId);
        }
    }
}
