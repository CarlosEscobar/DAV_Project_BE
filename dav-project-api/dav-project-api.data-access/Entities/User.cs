using System;
using System.Collections.Generic;

namespace dav_project_api.data_access.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<GroceryList> GroceryLists { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}
