using ShorteningWebService.Services.Models;

namespace ShorteningWebService.Services
{
    public interface IVisitReportService
    {
        void SaveInvalidVisit(string shorted);
        void SaveVisit(LinkMap result);
    }
}