using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public interface ILockedResource
    {
        string ResourceId { get; set; }
        string Owner { get; set; }
        string Comment { get; set; }
        DateTime ExpirationTime { get; set; }
    }
}
