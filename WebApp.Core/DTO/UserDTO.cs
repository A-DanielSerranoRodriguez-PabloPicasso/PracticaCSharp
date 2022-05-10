using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUser.Core.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }

        public UserDTO(string userName, string password, string email, string birthDate)
        {
            UserName = userName;
            Password = password;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
