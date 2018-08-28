using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public class LockedResourceResponse : ILockedResourceResponse
    {
        public string Key { get; set; }
        public bool IsLocked { get; set; }
        public string Owner { get; set; }
    }
}
