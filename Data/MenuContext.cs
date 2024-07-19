using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite key for DishIngredient
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });

            // Configure relationships for DishIngredient
            modelBuilder.Entity<DishIngredient>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(i => i.IngredientId);

            // Seed data for Dish
            // Corrected: Ensure the Id property is set and correct property names are used
            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margheritta", Price = 400, ImagUrl = "https://imgs.search.brave.com/F5mqn8OwsbQInaxf7FpT-S6cNU4QnXttBfcmfAn90GI/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/ZnJlZS1waG90by9w/aXp6YV8xNDQ2Mjct/Mzk1MDAuanBnP3Np/emU9NjI2JmV4dD1q/cGc" });

            // Seed data for Ingredient
            // Corrected: Ensure proper seeding of Ingredient entities
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, IngredientName = "Cheese" },  // Corrected typo: "Chees" to "Cheese"
                new Ingredient { IngredientId = 2, IngredientName = "Tomato Sauce" }
            );

            // Seed data for DishIngredient
            // Corrected: Ensure proper seeding of DishIngredient entities
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
