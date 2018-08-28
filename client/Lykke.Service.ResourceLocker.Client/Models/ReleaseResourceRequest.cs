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
        /// Locked owner
        /// </summary>
        public string Owner { get; set; }
    }
}
