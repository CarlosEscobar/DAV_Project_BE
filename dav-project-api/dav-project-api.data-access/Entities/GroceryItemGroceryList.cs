using System;

namespace dav_project_api.data_access.Entities
{
    public class GroceryItemGroceryList
    {
        public Guid GroceryItemId { get; set; }
        public virtual GroceryItem GroceryItem { get; set; }
        public Guid GroceryListId { get; set; }
        public virtual GroceryList GroceryList { get; set; }
    }
}
