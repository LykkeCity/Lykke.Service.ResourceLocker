using System;

namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public class LockedResourceRequest : ILockedResourceRequest
    {
        public string ResourceId { get; set; }
        public string ServiceName { get; set; }
        public string Owner { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
