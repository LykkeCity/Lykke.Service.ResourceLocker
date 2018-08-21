using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public class ReleaseResourceRequest : IReleaseResourceRequest
    {
        public string Key { get; set; }
        public string ResourceId { get; set; }
    }
}
