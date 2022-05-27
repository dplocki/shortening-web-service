namespace ShorteningWebService.Services.Models
{
    public class LinkMap
    {
        public Guid Id { get; set; }
        public string OriginalLink { get; set; } = default!;
        public string Shorted { get; set; } = default!;
    }
}