using api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class LufsDbContext : DbContext
    {
        public LufsDbContext(DbContextOptions<LufsDbContext> options) : base(options) { }

        public DbSet<News> News { get; set; } = null!;
    }
}
