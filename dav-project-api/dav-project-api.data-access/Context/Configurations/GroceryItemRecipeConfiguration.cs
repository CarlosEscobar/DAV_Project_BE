using dav_project_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dav_project_api.data_access.Context
{
    public class GroceryItemRecipeConfiguration : IEntityTypeConfiguration<GroceryItemRecipe>
    {
        public void Configure(EntityTypeBuilder<GroceryItemRecipe> builder)
        {
            builder.HasKey(groceryItemRecipe => new { groceryItemRecipe.GroceryItemId, groceryItemRecipe.RecipeId });
            builder.HasOne(groceryItemRecipe => groceryItemRecipe.GroceryItem)
                   .WithMany(groceryItem => groceryItem.GroceryItemRecipes)
                   .HasForeignKey(groceryItemRecipe => groceryItemRecipe.GroceryItemId);
            builder.HasOne(groceryItemRecipe => groceryItemRecipe.Recipe)
                   .WithMany(recipe => recipe.GroceryItemRecipes)
                   .HasForeignKey(groceryItemRecipe => groceryItemRecipe.RecipeId);
        }
    }
}
