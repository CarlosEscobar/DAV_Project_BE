using dav_project_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dav_project_api.data_access.Context
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.HasKey(reminder => reminder.Id);

            builder.HasOne(reminder => reminder.User)
                   .WithMany(user => user.Reminders)
                   .HasForeignKey(reminder => reminder.UserId)
                   .IsRequired();
        }
    }
}
