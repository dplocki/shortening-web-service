using Microsoft.AspNetCore.Mvc;

namespace ShorteningWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkMapController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;

        public LinkMapController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
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
            var newObject = new LinkMap()
            {
                Id = Guid.Parse(linkMapCreateDTO.Id),
                OriginalLink = linkMapCreateDTO.Url,
                Shorted = RandomString(),
            };

            databaseContext.Add(newObject);
            databaseContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult<LinkMap> Get(Guid id)
        {
            var result = databaseContext.LinkMaps.FirstOrDefault(lm => lm.Id.Equals(id));
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
            return databaseContext.LinkMaps.ToArray();
        }

        private static Random random = new Random();
        private static string RandomString()
        {
            const int length = 10;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}
