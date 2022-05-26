using Microsoft.EntityFrameworkCore;
using ShorteningWebService.Models;

namespace ShorteningWebService
{
    public class DatabaseContext : DbContext
    {
        public DbSet<LinkMap> LinkMaps { get; set; }
        public DbSet<LinkMapUse> LinkMapUses { get; set; }
        public DbSet<LinkMapError> LinkMapErrors { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
