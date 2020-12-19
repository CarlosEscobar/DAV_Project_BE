using System;

namespace dav_project_api.data_access.Entities
{
    public class Reminder
    {
        public Guid Id { get; set; }
        public DateTime TriggerDate { get; set; }
        public string Message { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
