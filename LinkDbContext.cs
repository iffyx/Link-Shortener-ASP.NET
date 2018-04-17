using Microsoft.EntityFrameworkCore;
using projekt2.Models;

namespace projekt2
{
    public class LinkDbContext : DbContext
    {
        public LinkDbContext(DbContextOptions<LinkDbContext> options) : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }
    }
}