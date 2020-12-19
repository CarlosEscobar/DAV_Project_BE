using System;
using System.Collections.Generic;

namespace dav_project_api.data_access.Entities
{
    public class GroceryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GroceryItemGroceryList> GroceryItemGroceryLists { get; set; }
        public virtual ICollection<GroceryItemRecipe> GroceryItemRecipes { get; set; }
    }
}
