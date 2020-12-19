using System;
using System.Collections.Generic;

namespace dav_project_api.data_access.Entities
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GroceryItemRecipe> GroceryItemRecipes { get; set; }
    }
}
