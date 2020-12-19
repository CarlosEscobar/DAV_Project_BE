using dav_project_api.data_access.Entities;
using dav_project_api.data_access.UnitOfWork;
using System;
using System.Linq;

namespace dav_project_api.business_logic.Services
{
    public class ReminderService : IReminderService
    {
        private IUnitOfWork unitOfWork;

        public ReminderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public AddReminderResponse DoAddReminder(AddReminder addReminderModel)
        {
            try
            {
                using (unitOfWork)
                {
                    User theUser = unitOfWork.UserRepository.GetById(Guid.Parse(addReminderModel.Token));
                    if (theUser == null)
                    {
                        return new AddReminderResponse()
                        {
                            ResponseMessage = "Error: Usuario no encontrado."
                        };
                    }

                    unitOfWork.ReminderRepository.Create(new Reminder()
                    {
                        Id = Guid.NewGuid(),
                        TriggerDate = GetTriggerDateFromMessage(addReminderModel.Message.ToLower()),
                        Message = addReminderModel.Message,
                        UserId = theUser.Id
                    });
                    unitOfWork.Commit();

                    return new AddReminderResponse()
                    {
                        ResponseMessage = "Success"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime GetTriggerDateFromMessage(string message)
        {
            DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
            if (message.Contains("sunday"))
            {
                return startOfWeek;
            }
            else if (message.Contains("monday"))
            {
                return startOfWeek.AddDays(1);
            }
            else if (message.Contains("tuesday"))
            {
                return startOfWeek.AddDays(2);
            }
            else if (message.Contains("wednesday"))
            {
                return startOfWeek.AddDays(3);
            }
            else if (message.Contains("thursday"))
            {
                return startOfWeek.AddDays(4);
            }
            else if (message.Contains("friday"))
            {
                return startOfWeek.AddDays(5);
            }
            else if (message.Contains("saturday"))
            {
                return startOfWeek.AddDays(6);
            }
            return DateTime.Now;
        }
    }
}
