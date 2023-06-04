using Bulky.Models;
using Microsoft.EntityFrameworkCore;
namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Drink> Drinks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Drink>().HasData(
                new Drink { Id = 1, Name = "Coca Cola", Description = "This is very yummy!", CaloriesPerServing = 230 },
                new Drink { Id = 2, Name = "Fanta", Description = "This is very yummy!", CaloriesPerServing = 240 },
                new Drink { Id = 3, Name = "Pepsi", Description = "This is very yummy!", CaloriesPerServing = 250 },
                new Drink { Id = 4, Name = "Sprite", Description = "This is very yummy!", CaloriesPerServing = 260 }
                );
        }
        
        

    }
}
