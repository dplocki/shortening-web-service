using ShorteningWebService.Models;

namespace ShorteningWebService.Services
{
    public interface ILinkService
    {
        LinkMap? GetLinkMapByShortened(string shortened);
        void BuildLinkMap(Guid id, string url);
        IEnumerable<LinkMap> GetAllLinksMaps();
        LinkMap? GetLinkMap(Guid id);
    }
}