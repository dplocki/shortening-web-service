using System.ComponentModel.DataAnnotations;

namespace ShorteningWebService.Models
{
    public class LinkMap
    {
        [Key]
        public Guid Id { get; set; }
        public string OriginalLink { get; set; }
        public string Shorted { get; set; }
    }
}