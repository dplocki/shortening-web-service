using ShorteningWebService.Database;
using ShorteningWebService.Models;

namespace ShorteningWebService.Services
{
    internal class VisitReportService : IVisitReportService
    {
        private readonly DatabaseContext databaseContext;

        public VisitReportService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void SaveInvalidVisit(string shorted)
        {
            this.databaseContext.Add(new LinkMapError()
            {
                Link = shorted,
                Time = DateTime.Now,
            });

            this.databaseContext.SaveChanges();
        }

        public void SaveVisit(LinkMap result)
        {
            this.databaseContext.Add(new LinkMapUse()
            {
                LinkMap = result.Id,
                When = DateTime.Now,
            });

            this.databaseContext.SaveChanges();
        }
    }
}
