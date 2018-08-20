using Lykke.Service.ResourceLocker.Core.Domain;
using System.Threading.Tasks;

namespace Lykke.Service.ResourceLocker.Core.Services
{
    public interface IResourceLockService
    {
        Task<ILockedResource> GetAsync(string blockId);
        void Block(ILockedResource lockedResource);
    }
}
