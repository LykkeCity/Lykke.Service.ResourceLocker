using Lykke.Service.ResourceLocker.Core.Domain;
using System.Threading.Tasks;

namespace Lykke.Service.ResourceLocker.Core.Services
{
    public interface IResourceLockService
    {
        Task<bool> Release(IReleaseResourceRequest lockedResource);
        Task<ILockedResourceResponse> Block(ILockedResourceRequest lockedResource);
    }
}
