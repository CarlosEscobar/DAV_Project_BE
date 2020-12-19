using dav_project_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dav_project_api.data_access.Context
{
    public class GroceryListConfiguration : IEntityTypeConfiguration<GroceryList>
    {
        public void Configure(EntityTypeBuilder<GroceryList> builder)
        {
            builder.HasKey(groceryList => groceryList.Id);

            builder.HasOne(groceryList => groceryList.User)
                   .WithMany(user => user.GroceryLists)
                   .HasForeignKey(groceryList => groceryList.UserId)
                   .IsRequired();
        }
    }
}
