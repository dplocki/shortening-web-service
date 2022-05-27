using Microsoft.AspNetCore.Mvc;
using ShorteningWebService.Controllers.DTO;
using ShorteningWebService.Services;

namespace ShorteningWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkMapController : ControllerBase
    {
        private readonly ILinkMapService linkService;
        private readonly IGuidService guidService;

        public LinkMapController(ILinkMapService linkService, IGuidService guidService)
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
        public ActionResult Add(LinkMapAddDTO linkMapCreateDTO)
        {
            if (ModelState.IsValid
                && guidService.TryParseGuid(linkMapCreateDTO.Id, out var guid)
                && Uri.IsWellFormedUriString(linkMapCreateDTO.Url, UriKind.Absolute))
            {
                linkService.Build(guid, linkMapCreateDTO.Url);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public ActionResult<LinkMapGetDTO> Get(Guid id)
        {
            var result = linkService.Get(id);
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
                .GetAll()
                .Select(lm => new LinkMapGetDTO()
                {
                    OriginalLink = lm.OriginalLink,
                    Shorted = lm.Shorted
                });
        }
    }
}
