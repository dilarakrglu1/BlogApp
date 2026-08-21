using Microsoft.EntityFrameworkCore;

namespace BlogApp.Entities
{
    public class Veritabani : DbContext
    {
        public DbSet< User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
