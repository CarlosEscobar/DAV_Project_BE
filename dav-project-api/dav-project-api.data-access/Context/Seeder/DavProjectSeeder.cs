using dav_project_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;

namespace dav_project_api.data_access.Context
{
    public static class DavProjectSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Grocery Items
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.ham);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.sausage);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.bacon);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.meat);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.pork);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.chicken);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.milk);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.cheese);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.yogurt);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.egg);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.bread);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.rice);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.banana);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.apple);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.orange);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.tomatoe);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.onion);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.lettuce);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.salt);
            modelBuilder.Entity<GroceryItem>().HasData(SeederConstants.pepper);

            // Recipes
            modelBuilder.Entity<Recipe>().HasData(SeederConstants.hamburger);
            modelBuilder.Entity<Recipe>().HasData(SeederConstants.salad);
            modelBuilder.Entity<Recipe>().HasData(SeederConstants.orangeChicken);

            // Grocery Item Recipe Association
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.hamburgerBread);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.hamburgerMeat);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.hamburgerCheese);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.hamburgerTomatoe);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.hamburgerLettuce);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.saladLettuce);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.saladTomatoe);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.saladOnion);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.saladApple);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.orangeChickenChicken);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.orangeChickenOrange);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.orangeChickenSalt);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.orangeChickenPepper);
            modelBuilder.Entity<GroceryItemRecipe>().HasData(SeederConstants.orangeChickenOnion);
        }
    }
}
