using System.ComponentModel.DataAnnotations;

namespace ShorteningWebService.Controllers.DTO
{
    public class LinkMapAddDTO
    {
        [Required]
        public string Id { get; set; } = default!;

        [Required]
        public string Url { get; set; } = default!;
    }
}