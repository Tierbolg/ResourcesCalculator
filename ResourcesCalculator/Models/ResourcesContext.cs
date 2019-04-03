
using Microsoft.EntityFrameworkCore;
using ResourcesCalculator;
namespace ResourcesCalculator.Models
{
    public class ResourcesContext : DbContext
    {
        public ResourcesContext(DbContextOptions<ResourcesContext> options)
            : base(options) { }
        public DbSet<BuildingItem> BuildingsItems { get; set; }
    }
}