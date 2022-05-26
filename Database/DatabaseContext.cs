using Microsoft.EntityFrameworkCore;
using ShorteningWebService.Database.Entities;

namespace ShorteningWebService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<LinkMap> LinkMaps { get; set; } = null!;
        public DbSet<LinkMapUse> LinkMapUses { get; set; } = null!;
        public DbSet<LinkMapError> LinkMapErrors { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
    }
}
