namespace ShorteningWebService.Controllers.DTO
{
    public class LinkMapGetDTO
    {
        public string OriginalLink { get; set; } = default!;
        public string Shorted { get; set; } = default!;
    }
}
