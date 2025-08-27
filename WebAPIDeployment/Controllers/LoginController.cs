using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDeployment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public string Login(RequestBodyLogin request)
        {
            return _loginService.LoginWithUserNamePassword(request.username, request.password);
        }

    }

    public class RequestBodyLogin()
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
