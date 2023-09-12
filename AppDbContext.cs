using GewanInfo.Model;
using Microsoft.EntityFrameworkCore;

namespace GewanInfo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ItemMaster> ItemMasters { get; set; }
        public DbSet<ItemDetail> ItemDetails { get; set; }
    }
}
