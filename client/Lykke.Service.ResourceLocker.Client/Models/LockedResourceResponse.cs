namespace Lykke.Service.ResourceLocker.Client.Models
{
    /// <summary>
    /// Response model for locked resource
    /// </summary>
    public class LockedResourceResponse
    {
        /// <summary>
        /// Cache key for locked resource
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Flag of blocked resource
        /// </summary>
        public bool IsLocked { get; set; }
        /// <summary>
        /// Owner
        /// </summary>
        public string Owner { get; set; }
    }
}
