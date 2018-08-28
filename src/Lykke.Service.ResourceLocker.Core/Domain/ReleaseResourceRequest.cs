namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public class ReleaseResourceRequest : IReleaseResourceRequest
    {
        public string Key { get; set; }
        public string Owner { get; set; }
    }
}
