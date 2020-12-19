using dav_project_api.data_access.Entities;
using dav_project_api.data_access.UnitOfWork;
using System;
using System.Linq;

namespace dav_project_api.business_logic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUnitOfWork unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public LoginResponse DoLogin(Login loginModel)
        {
            try
            {
                using (unitOfWork)
                {
                    var theUser = unitOfWork.UserRepository.GetAll().FirstOrDefault(user => user.Username == loginModel.Username
                                                                                         && user.Password == loginModel.Password);
                    if (theUser != null)
                    {
                        return new LoginResponse()
                        {
                            ResponseMessage = "Success",
                            Token = theUser.Id.ToString()
                        };
                    }
                    return new LoginResponse()
                    {
                        ResponseMessage = "Error: Usuario y/o contraseña inválidos.",
                        Token = ""
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RegisterResponse DoRegister(Register registerModel)
        {
            try
            {
                using (unitOfWork)
                {
                    var theUser = unitOfWork.UserRepository.GetAll()
                                                           .FirstOrDefault(user => user.Username == registerModel.Username);

                    if (theUser != null)
                    {
                        return new RegisterResponse()
                        {
                            ResponseMessage = "Error: Usuario tomado."
                        };
                    }

                    unitOfWork.UserRepository.Create(new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = registerModel.Name,
                        Username = registerModel.Username,
                        Password = registerModel.Password
                    });
                    unitOfWork.Commit();

                    return new RegisterResponse()
                    {
                        ResponseMessage = "Success"
                    };
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
