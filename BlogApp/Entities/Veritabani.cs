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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "dilara",
                Email = "dilara.krglu@gmail.com",
                Password = "123456",
                CreatedDate = new DateTime(2026, 08, 21),
                Blogs = []
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
