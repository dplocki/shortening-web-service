using Microsoft.AspNetCore.Mvc;
using ShorteningWebService.Models;
using ShorteningWebService.Services;

namespace ShorteningWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkMapController : ControllerBase
    {
        private ILinkService linkService;

        public LinkMapController(ILinkService linkService)
        {
            this.linkService = linkService;
        }

        [HttpGet]
        [Route("NewId")]
        public string GetNewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(LinkMapCreateDTO linkMapCreateDTO)
        {
            var guid = Guid.Parse(linkMapCreateDTO.Id);

            linkService.BuildLinkMap(guid, linkMapCreateDTO.Url);

            return Ok();
        }

        [HttpGet]
        public ActionResult<LinkMap> Get(Guid id)
        {
            var result = linkService.GetLinkMap(id);
            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<LinkMap> GetAll()
        {
            return linkService.GetAllLinksMaps();
        }
    }
}
