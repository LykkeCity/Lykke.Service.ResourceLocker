using System;

namespace Lykke.Service.ResourceLocker.Client.Models
{
    /// <summary>
    /// Request model for lock resource
    /// </summary>
    public class LockedResourceRequest
    {
        /// <summary>
        /// Locked ResourceId
        /// </summary>
        public string ResourceId { get; set; }
        /// <summary>
        /// Service name, which locked resource
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Owner
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// Expiration time for locked resource
        /// </summary>
        public DateTime ExpirationTime { get; set; }
    }
}
