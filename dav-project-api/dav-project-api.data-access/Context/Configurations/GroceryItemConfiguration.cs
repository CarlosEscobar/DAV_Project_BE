using dav_project_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dav_project_api.data_access.Context
{
    public class GroceryItemConfiguration : IEntityTypeConfiguration<GroceryItem>
    {
        public void Configure(EntityTypeBuilder<GroceryItem> builder)
        {
            builder.HasKey(groceryItem => groceryItem.Id);
        }
    }
}
