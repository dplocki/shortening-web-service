using ShorteningWebService.Models;

namespace ShorteningWebService.Services
{
    public interface ILinkService
    {
        LinkMap? GetLinkMapByShorted(string shorted);
        void BuildLinkMap(Guid id, string url);
        IEnumerable<LinkMap> GetAllLinksMaps();
        LinkMap? GetLinkMap(Guid id);
    }
}