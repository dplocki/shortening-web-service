using Microsoft.EntityFrameworkCore;

namespace ShorteningWebService
{
    [Keyless]
    public class LinkMapUse
    {
        public LinkMap LinkMap { get; set; }
        public DateTime When { get; set; }
    }
}