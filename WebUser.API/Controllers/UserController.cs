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
        public ActionResult<UserDTO> Login(LoginDTO user)
        {
            if (UserBL.Login(user))
                return Ok(user);
            else
                return BadRequest();
        }

        [HttpPost("register")]
        public ActionResult<bool> Register(UserDTO user)
        {
            if (UserBL.Register(user))
                return Ok(true);
            else
                return BadRequest(false);
        }

        [HttpDelete("remove")]
        public ActionResult<bool> Delete(string username)
        {
            if(UserBL.DeleteUser(username))
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpGet("get_users")]
        public List<UserDTO> GetUsers()
        {
            return UserBL.GetUsers();
        }

        [HttpGet("get_user")]
        public UserDTO GetUser(string username)
        {
            return UserBL.GetUser(username);
        }

        [HttpPost("update_user")]
        public bool UpdateUser(string username, UserDTO user)
        {
            return UserBL.UpdateUser(username, user);
        }
    }
}
