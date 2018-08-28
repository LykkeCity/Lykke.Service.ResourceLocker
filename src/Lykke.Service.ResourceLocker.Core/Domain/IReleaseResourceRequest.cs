namespace Lykke.Service.ResourceLocker.Core.Domain
{
    public interface IReleaseResourceRequest
    {
        string Key { get; set; }
        string Owner { get; set; }
    }
}
