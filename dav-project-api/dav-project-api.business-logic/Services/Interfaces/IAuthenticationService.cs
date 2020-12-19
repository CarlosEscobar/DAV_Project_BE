namespace dav_project_api.business_logic.Services
{
    public interface IAuthenticationService
    {
        public RegisterResponse DoRegister(Register registerModel);
        public LoginResponse DoLogin(Login loginModel);
    }
}
