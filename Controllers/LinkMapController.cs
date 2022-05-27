using Microsoft.AspNetCore.Mvc;
using ShorteningWebService.Controllers.DTO;
using ShorteningWebService.Services;

namespace ShorteningWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkMapController : ControllerBase
    {
        private readonly ILinkService linkService;
        private readonly IGuidService guidService;

        public LinkMapController(ILinkService linkService, IGuidService guidService)
        {
            this.linkService = linkService;
            this.guidService = guidService;
        }

        [HttpGet]
        [Route("NewId")]
        public string GetNewGuid()
        {
            return guidService.NewGuid().ToString();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(LinkMapCreateDTO linkMapCreateDTO)
        {
            if (guidService.TryParseGuid(linkMapCreateDTO.Id, out var guid))
            {
                linkService.BuildLinkMap(guid, linkMapCreateDTO.Url);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult<LinkMapGetDTO> Get(Guid id)
        {
            var result = linkService.GetLinkMap(id);
            if (result != null)
            {
                return new LinkMapGetDTO()
                {
                    OriginalLink = result.OriginalLink,
                    Shorted = result.Shorted
                };
            }

            return NotFound();
        }

        [HttpGet]
        [Route("All")]
        public IEnumerable<LinkMapGetDTO> GetAll()
        {
            return linkService
                .GetAllLinksMaps()
                .Select(lm => new LinkMapGetDTO()
                {
                    OriginalLink = lm.OriginalLink,
                    Shorted = lm.Shorted
                });
        }
    }
}
