using dav_project_api.data_access.Entities;
using System;

namespace dav_project_api.data_access.Context
{
    public static class SeederConstants
    {
        //Grocery Items
        //Meats,Chicken,Pork
        public static GroceryItem ham = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "ham"
        };
        public static GroceryItem sausage = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "sausage"
        };
        public static GroceryItem bacon = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "bacon"
        };
        public static GroceryItem meat = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "meat"
        };
        public static GroceryItem pork = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "pork"
        };
        public static GroceryItem chicken = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "chicken"
        };
        //Lactose
        public static GroceryItem milk = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "milk"
        };
        public static GroceryItem cheese = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "cheese"
        };
        public static GroceryItem yogurt = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "yogurt"
        };
        public static GroceryItem egg = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "egg"
        };
        //Wheats
        public static GroceryItem bread = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "bread"
        };
        public static GroceryItem rice = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "rice"
        };
        //Fruits
        public static GroceryItem banana = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "banana"
        };
        public static GroceryItem apple = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "apple"
        };
        public static GroceryItem orange = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "orange"
        };
        //Vegetables
        public static GroceryItem tomatoe = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "tomatoe"
        };
        public static GroceryItem onion = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "onion"
        };
        public static GroceryItem lettuce = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "lettuce"
        };
        //Spices
        public static GroceryItem salt = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "salt"
        };
        public static GroceryItem pepper = new GroceryItem
        {
            Id = Guid.NewGuid(),
            Name = "pepper"
        };

        //Recipes
        public static Recipe hamburger = new Recipe
        {
            Id = Guid.NewGuid(),
            Name = "hamburger"
        };
        public static Recipe salad = new Recipe
        {
            Id = Guid.NewGuid(),
            Name = "salad"
        };
        public static Recipe orangeChicken = new Recipe
        {
            Id = Guid.NewGuid(),
            Name = "orange chicken"
        };

        //GroceryItem Recipe
        public static GroceryItemRecipe hamburgerBread = new GroceryItemRecipe
        {
            RecipeId = hamburger.Id,
            GroceryItemId = bread.Id
        };
        public static GroceryItemRecipe hamburgerMeat = new GroceryItemRecipe
        {
            RecipeId = hamburger.Id,
            GroceryItemId = meat.Id
        };
        public static GroceryItemRecipe hamburgerCheese = new GroceryItemRecipe
        {
            RecipeId = hamburger.Id,
            GroceryItemId = cheese.Id
        };
        public static GroceryItemRecipe hamburgerTomatoe = new GroceryItemRecipe
        {
            RecipeId = hamburger.Id,
            GroceryItemId = tomatoe.Id
        };
        public static GroceryItemRecipe hamburgerLettuce = new GroceryItemRecipe
        {
            RecipeId = hamburger.Id,
            GroceryItemId = lettuce.Id
        };

        public static GroceryItemRecipe saladLettuce = new GroceryItemRecipe
        {
            RecipeId = salad.Id,
            GroceryItemId = lettuce.Id
        };
        public static GroceryItemRecipe saladTomatoe = new GroceryItemRecipe
        {
            RecipeId = salad.Id,
            GroceryItemId = tomatoe.Id
        };
        public static GroceryItemRecipe saladOnion = new GroceryItemRecipe
        {
            RecipeId = salad.Id,
            GroceryItemId = onion.Id
        };
        public static GroceryItemRecipe saladApple = new GroceryItemRecipe
        {
            RecipeId = salad.Id,
            GroceryItemId = apple.Id
        };

        public static GroceryItemRecipe orangeChickenChicken = new GroceryItemRecipe
        {
            RecipeId = orangeChicken.Id,
            GroceryItemId = chicken.Id
        };
        public static GroceryItemRecipe orangeChickenOrange = new GroceryItemRecipe
        {
            RecipeId = orangeChicken.Id,
            GroceryItemId = orange.Id
        };
        public static GroceryItemRecipe orangeChickenSalt = new GroceryItemRecipe
        {
            RecipeId = orangeChicken.Id,
            GroceryItemId = salt.Id
        };
        public static GroceryItemRecipe orangeChickenPepper = new GroceryItemRecipe
        {
            RecipeId = orangeChicken.Id,
            GroceryItemId = pepper.Id
        };
        public static GroceryItemRecipe orangeChickenOnion = new GroceryItemRecipe
        {
            RecipeId = orangeChicken.Id,
            GroceryItemId = onion.Id
        };
    }
}
