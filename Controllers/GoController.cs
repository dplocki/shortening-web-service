using Microsoft.AspNetCore.Mvc;

namespace ShorteningWebService.Controllers
{
    [ApiController]
    [Route("go")]
    public class GoController : ControllerBase
    {
        private DatabaseContext databaseContext;

        public GoController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet]
        public ActionResult Go(string shorted)
        {
            var result = databaseContext.LinkMaps.FirstOrDefault(lm => lm.Shorted.Equals(shorted));
            if (result == null)
            {
                this.databaseContext.Add(new LinkMapError()
                {
                    Link = shorted,
                    Time = DateTime.Now,
                });

                this.databaseContext.SaveChanges();
                return NotFound();
            }

            this.databaseContext.Add(new LinkMapUse()
            {
                LinkMap = result,
                When = DateTime.Now,
            });
            this.databaseContext.SaveChanges();

            return Redirect(result.OriginalLink);
        }
    }
}
