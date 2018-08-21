using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ResourceLocker.Client.Models
{
    /// <summary>
    /// Release model for locked resource
    /// </summary>
    public class ReleaseResourceRequest
    {
        /// <summary>
        /// Cache key for locked resource
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Locked ResourceId
        /// </summary>
        public string ResourceId { get; set; }
    }
}
