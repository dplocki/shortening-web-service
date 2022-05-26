using Microsoft.AspNetCore.Mvc;
using ShorteningWebService.Models;
using ShorteningWebService.Services;

namespace ShorteningWebService.Controllers
{
    [ApiController]
    public class GoController : ControllerBase
    {
        private ILinkService linkService;
        private IVisitReportService visitReportService;

        public GoController(IVisitReportService visitReportService, ILinkService linkService)
        {
            this.visitReportService = visitReportService;
            this.linkService = linkService;
        }

        [HttpGet]
        [Route("~/go/{shorted}")]
        public ActionResult Go(string shorted)
        {
            var result = linkService.GetLinkMapByShorted(shorted);
            if (result == null)
            {
                visitReportService.SaveInvalidVisit(shorted);
                return NotFound();
            }

            visitReportService.SaveVisit(result);

            return Redirect(result.OriginalLink);
        }
    }
}
