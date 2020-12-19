using System;
using Microsoft.AspNetCore.Mvc;
using dav_project_api.business_logic.Services;
using dav_project_api.business_logic;

namespace dav_project_api.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPut]
        public ActionResult DoLogin([FromBody] Login loginModel)
        {
            try
            {
                return Ok(authenticationService.DoLogin(loginModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult DoRegister([FromBody] Register registerModel)
        {
            try
            {
                return Ok(authenticationService.DoRegister(registerModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
