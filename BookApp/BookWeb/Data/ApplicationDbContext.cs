using BookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Science", DisplayOrder = 1},
                new Category { Id = 2, Name = "Novel", DisplayOrder = 2},
                new Category { Id = 3, Name = "Action", DisplayOrder = 3}
                );
        }
        public DbSet<Category> Categories { get; set; }
    }
}
