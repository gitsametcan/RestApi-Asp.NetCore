using BackendWorks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext dbContext)
        {
            _userContext = dbContext;
        }

        [HttpGet]
        [Route("Login/{userName}/{password}")]
        public async Task<ActionResult<User>> LoginUser(string userName, string password)
        {
            if (_userContext.Users == null)
            {
                return NotFound("Null List");
            }

            List<User> Users = await _userContext.Users.ToListAsync();

            User temp = new User();
            temp.UserId = 0; // Fix this!!!!!!!!!!!!!!!

            foreach (User user in Users)
            {
                // Where is the output of
                // Console.WriteLine("user" + user.Name + " " + password);


                if (user.UserName.Equals(userName) && user.Password.Equals(password)) // .equals vs ==
                {
                    temp = user;
                }
            }

            //var user = await _userContext.Users.FindAsync(temp.UserId);

            if (temp.UserId == 0)
            {
                return NotFound("User not found!");
            }

            return temp;
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUserItem(User user)
        {
            //first.Id = Empty;
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();

            return CreatedAtAction(nameof(User), new { id = user.UserId }, user);
        }
    }
}
