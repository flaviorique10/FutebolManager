using FutebolManager.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace FutebolManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Time> Times { get; set; }
    }
}
