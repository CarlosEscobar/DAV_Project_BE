using System;
using Microsoft.AspNetCore.Mvc;
using dav_project_api.business_logic.Services;
using dav_project_api.business_logic;

namespace dav_project_api.Controllers
{
    [ApiController]
    [Route("reminder")]
    public class ReminderController : ControllerBase
    {
        private IReminderService reminderService;

        public ReminderController(IReminderService reminderService)
        {
            this.reminderService = reminderService;
        }

        [HttpPost]
        public ActionResult DoAddReminder([FromBody] AddReminder addReminderModel)
        {
            try
            {
                return Ok(reminderService.DoAddReminder(addReminderModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
