namespace ShorteningWebService.Services
{
    public interface IGuidService
    {
        Guid NewGuid();
        bool TryParseGuid(string guid, out Guid id);
    }
}