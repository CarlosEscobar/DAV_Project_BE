using dav_project_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;

namespace dav_project_api.data_access.Context
{
    public class DavProjectContext : DbContext
    {
        public DavProjectContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<GroceryItem> GroceryItems { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<GroceryItemGroceryList> GroceryItemGroceryLists { get; set; }
        public DbSet<GroceryItemRecipe> GroceryItemRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReminderConfiguration());
            modelBuilder.ApplyConfiguration(new GroceryItemConfiguration());
            modelBuilder.ApplyConfiguration(new GroceryListConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new GroceryItemGroceryListConfiguration());
            modelBuilder.ApplyConfiguration(new GroceryItemRecipeConfiguration());

            DavProjectSeeder.SeedData(modelBuilder);
        }
    }
}