using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUser.DAL.Contracts;
using WebUser.DAL.Tables;

namespace WebUser.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {

        public bool Login(User user)
        {
            var foundUser = BBDD.Almacen.users.FirstOrDefault(u => u.UserName == user.UserName);

            if (foundUser == null)
                return false;
            else
                return foundUser.UserName.Equals(user.UserName) && foundUser.Password.Equals(user.Password) ? true : false;
        }

        public bool Register(User user)
        {
            var foundUser = BBDD.Almacen.users.FirstOrDefault(u => u.UserName == user.UserName);

            if (foundUser != null)
                return false;

            BBDD.Almacen.users.Add(user);
            return true;
        }
        public List<User> GetUsers() => BBDD.Almacen.users;
    }
}
