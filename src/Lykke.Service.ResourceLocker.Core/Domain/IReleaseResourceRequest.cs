using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public interface IReleaseResourceRequest
    {
        string Key { get; set; }
        string ResourceId { get; set; }
    }
}
