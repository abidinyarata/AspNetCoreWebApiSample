using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Connection string...");
        //        //optionsBuilder.UseLazyLoadingProxies();
        //    }
        //}
    }
}
