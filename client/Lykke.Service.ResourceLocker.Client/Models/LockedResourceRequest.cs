using System;

namespace Lykke.Service.ResourceLocker.Client.Models
{
    public class LockedResourceRequest
    {
        public string ResourceId { get; set; }
        public string ServiceName { get; set; }
        public string Owner { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
