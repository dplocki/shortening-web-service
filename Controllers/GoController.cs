using Microsoft.AspNetCore.Mvc;
using ShorteningWebService.Services;

namespace ShorteningWebService.Controllers
{
    [ApiController]
    public class GoController : ControllerBase
    {
        private readonly ILinkService linkService;
        private readonly IVisitReportService visitReportService;

        public GoController(IVisitReportService visitReportService, ILinkService linkService)
        {
            this.visitReportService = visitReportService;
            this.linkService = linkService;
        }

        [HttpGet]
        [Route("~/go/{shortened}")]
        public ActionResult Go(string shortened)
        {
            var result = linkService.GetLinkMapByShortened(shortened);
            if (result == null)
            {
                visitReportService.SaveInvalidVisit(shortened);
                return NotFound();
            }

            visitReportService.SaveVisit(result);

            return Redirect(result.OriginalLink);
        }
    }
}
