namespace ShorteningWebService.Models
{
    public class LinkMapError
    {
        public int Id { get; set; }
        public string Link { get; set; } = default!;
        public DateTime Time { get; set; }
    }
}