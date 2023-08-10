using BackendWorks.Models;
using BackendWorks.NonTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendWorks.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly UserContext _userContext;

        public AccountController(IJWTManagerRepository jWTManager, UserContext uc)
        {
            _jWTManager = jWTManager;
            _userContext = uc;
        }

        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string>
        {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
        };

            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(LoginRequest lr)
        {
            if (_userContext.Users == null)
            {
                return NotFound();
            }

            User user = _userContext.Users.FirstOrDefault(u => u.UserName == lr.userName);
            if (user == null)
            {
                return NotFound();
            }

            if (!user.UserName.Equals(lr.userName) && user.Password.Equals(lr.password))
            {
                return NotFound();
            }

            var token = _jWTManager.Authenticate(user, _userContext);

            if (token == null)
            {
                return Unauthorized();
            }

            LoginModel loginModel = new LoginModel();
            loginModel.user = user;
            loginModel.token = token.Token;

            return Ok(loginModel);
        }
    }
}
