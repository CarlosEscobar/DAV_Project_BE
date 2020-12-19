using System;
using System.Collections.Generic;

namespace dav_project_api.data_access.Entities
{
    public class GroceryList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<GroceryItemGroceryList> GroceryItemGroceryLists { get; set; }
    }
}
