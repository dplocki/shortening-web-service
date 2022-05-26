namespace ShorteningWebService.Services
{
    public interface IGuidService
    {
        Guid NewGuid();
        bool TryParseGuid(string id1, out Guid id);
    }
}