using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public interface ILockedResourceRequest
    {
        string ResourceId { get; set; }
        string ServiceName { get; set; }
        string Owner { get; set; }
        DateTime ExpirationTime { get; set; }
    }
}
