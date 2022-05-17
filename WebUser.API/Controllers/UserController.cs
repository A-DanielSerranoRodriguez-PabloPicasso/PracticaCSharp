using Microsoft.AspNetCore.Mvc;
using WebUser.BL.Contracts;
using WebUser.Core.DTO;

namespace WebUser.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserBL UserBL;

        public UserController(IUserBL userBL)
        {
            this.UserBL = userBL;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDTO user)
        {
            if (UserBL.Login(user))
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("register")]
        public ActionResult Register(UserDTO user)
        {
            if (UserBL.Register(user))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("get_users")]
        public List<UserDTO> GetUsers()
        {
            return UserBL.GetUsers();
        }
    }
}
