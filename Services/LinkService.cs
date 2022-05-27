using ShorteningWebService.Database;
using ShorteningWebService.Services.Models;

namespace ShorteningWebService.Services
{
    public class LinkService : ILinkMapService
    {
        private static readonly Random random = new();
        private readonly DatabaseContext databaseContext;

        public LinkService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Build(Guid id, string url)
        {
            var newObject = new Database.Entities.LinkMap()
            {
                Id = id,
                OriginalLink = url,
                Shorted = RandomString(),
            };

            databaseContext.Add(newObject);
            databaseContext.SaveChanges();
        }

        public LinkMap? Get(string shorted)
        {
            return ConvertLinkMap(databaseContext
                .LinkMaps
                .FirstOrDefault(lm => lm.Shorted.Equals(shorted)));
        }

        public LinkMap? Get(Guid id)
        {
            return ConvertLinkMap(databaseContext
                .LinkMaps
                .FirstOrDefault(lm => lm.Id.Equals(id)));
        }

        public IEnumerable<LinkMap> GetAll()
        {
            return databaseContext
                .LinkMaps
                .Select(lm => new LinkMap()
                {
                    Id = lm.Id,
                    OriginalLink = lm.OriginalLink,
                    Shorted = lm.Shorted
                });
        }

        private static LinkMap? ConvertLinkMap(Database.Entities.LinkMap? linkMap)
        {
            if (linkMap == null)
            {
                return null;
            }

            return new LinkMap()
            {
                Id = linkMap.Id,
                OriginalLink = linkMap.OriginalLink,
                Shorted = linkMap.Shorted
            };
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
