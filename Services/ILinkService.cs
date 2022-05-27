using ShorteningWebService.Services.Models;

namespace ShorteningWebService.Services
{
    public interface ILinkMapService
    {
        LinkMap? Get(Guid id);
        LinkMap? Get(string shortened);
        IEnumerable<LinkMap> GetAll();
        void Build(Guid id, string url);
    }
}