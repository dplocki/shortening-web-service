namespace ShorteningWebService.Database.Entities
{
    public class LinkMapError
    {
        public int Id { get; set; }
        public string Link { get; set; } = default!;
        public DateTime Time { get; set; }
    }
}