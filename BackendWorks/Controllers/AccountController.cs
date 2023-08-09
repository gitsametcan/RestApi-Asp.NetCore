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
        private readonly UserContext _uc;

        public AccountController(IJWTManagerRepository jWTManager, UserContext uc)
        {
            _jWTManager = jWTManager;
            _uc = uc;
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
        [Route("authenticate/{userName}/{password}")]
        public IActionResult Authenticate(string userName, string password)
        {
            Users users = new Users();
            users.Name = userName;
            users.Password = password;

            var token = _jWTManager.Authenticate(users,_uc);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
