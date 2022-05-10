using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUser.Core.DTO;

namespace WebUser.BL.Contracts
{
    public interface IUserBL
    {
        public bool Login(LoginDTO user);
        public bool Register(UserDTO user);
        public List<UserDTO> GetUsers();
    }
}
