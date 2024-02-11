using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UrlLink> urlLinks { get; set; }

    }
}
