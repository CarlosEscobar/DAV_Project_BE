using dav_project_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dav_project_api.data_access.Context
{
    public class GroceryItemGroceryListConfiguration : IEntityTypeConfiguration<GroceryItemGroceryList>
    {
        public void Configure(EntityTypeBuilder<GroceryItemGroceryList> builder)
        {
            builder.HasKey(groceryItemGroceryList => new { groceryItemGroceryList.GroceryItemId, groceryItemGroceryList.GroceryListId });
            builder.HasOne(groceryItemGroceryList => groceryItemGroceryList.GroceryItem)
                   .WithMany(groceryItem => groceryItem.GroceryItemGroceryLists)
                   .HasForeignKey(groceryItemGroceryList => groceryItemGroceryList.GroceryItemId);
            builder.HasOne(groceryItemGroceryList => groceryItemGroceryList.GroceryList)
                   .WithMany(groceryList => groceryList.GroceryItemGroceryLists)
                   .HasForeignKey(groceryItemGroceryList => groceryItemGroceryList.GroceryListId);
        }
    }
}
