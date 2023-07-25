using BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Si-Fi", DisplayOrder = 1 },
                new Category { Id = 2, Name = "History", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Novel", DisplayOrder = 3 }
            );
        }

    }
}
