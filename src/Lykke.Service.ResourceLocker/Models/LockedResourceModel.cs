using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Models
{
    public class LockedResourceModel
    {
        public string ResourceId { get; set; }
        public string Owner { get; set; }
        public string Comment { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
