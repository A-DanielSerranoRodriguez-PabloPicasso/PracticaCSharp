using Microsoft.AspNetCore.Mvc;
using WebUser.BL.Contracts;
using WebUser.Core.DTO;

namespace WebUser.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDTO user)
        {
            if (userBL.Login(user))
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("register")]
        public ActionResult Register(UserDTO user)
        {
            if (userBL.Register(user))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("get_users")]
        public List<UserDTO> GetUsers()
        {
            return userBL.GetUsers();
        }
    }
}
