using Microsoft.EntityFrameworkCore;
using AppAnime.Models;

namespace AppAnime.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Anime> Anime { get; set; }
    }
}