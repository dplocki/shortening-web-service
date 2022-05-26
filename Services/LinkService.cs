using ShorteningWebService.Database;
using ShorteningWebService.Database.Entities;

namespace ShorteningWebService.Services
{
    public class LinkService : ILinkService
    {
        private static readonly Random random = new();
        private readonly DatabaseContext databaseContext;

        public LinkService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void BuildLinkMap(Guid id, string url)
        {
            var newObject = new LinkMap()
            {
                Id = id,
                OriginalLink = url,
                Shorted = RandomString(),
            };

            databaseContext.Add(newObject);
            databaseContext.SaveChanges();
        }

        public LinkMap? GetLinkMapByShortened(string shorted)
        {
            return databaseContext
                .LinkMaps
                .FirstOrDefault(lm => lm.Shorted.Equals(shorted));
        }

        public LinkMap? GetLinkMap(Guid id)
        {
            return databaseContext
                .LinkMaps
                .FirstOrDefault(lm => lm.Id.Equals(id));
        }

        public IEnumerable<LinkMap> GetAllLinksMaps()
        {
            return databaseContext.LinkMaps.ToArray();
        }

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
