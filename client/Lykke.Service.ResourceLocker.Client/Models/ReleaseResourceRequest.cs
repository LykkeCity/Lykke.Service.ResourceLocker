using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Client.Models
{
    public class ReleaseResourceRequest
    {
        public string Key { get; set; }
        public string ResourceId { get; set; }
    }
}
