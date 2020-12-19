using System;

namespace dav_project_api.data_access.Entities
{
    public class GroceryItemRecipe
    {
        public Guid GroceryItemId { get; set; }
        public virtual GroceryItem GroceryItem { get; set; }
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
