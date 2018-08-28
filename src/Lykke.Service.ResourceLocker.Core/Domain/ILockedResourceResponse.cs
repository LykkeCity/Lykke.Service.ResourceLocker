using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public interface ILockedResourceResponse
    {
        string Key { get; set; }
        bool IsLocked { get; set; }
        string Owner { get; set; }
    }
}
