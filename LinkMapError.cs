using Microsoft.EntityFrameworkCore;

namespace ShorteningWebService
{
    [Keyless]
    public class LinkMapError
    {
        public string Link { get; set; }
        public DateTime Time { get; set; }
    }
}