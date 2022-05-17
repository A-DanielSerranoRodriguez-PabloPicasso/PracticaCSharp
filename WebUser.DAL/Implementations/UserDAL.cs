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
        public IESContext Context { get; set; }

        public UserDAL(IESContext context)
        {
            this.Context = context;
        }

        public User? GetUser(User user)
        {
            return Context.Users.FirstOrDefault(u => u.UserName == user.UserName);
        }
       
        public bool Login(User user)
        {
            var foundUser = GetUser(user);

            if (foundUser == null)
                return false;
            else
                return foundUser.UserName.Equals(user.UserName) && foundUser.Password.Equals(user.Password) ? true : false;
        }

        public bool Register(User user)
        {
            var foundUser = GetUser(user);

            if (foundUser != null)
                return false;

            Context.Users.Add(user);
            Context.SaveChanges();
            return true;
        }
        public List<User> GetUsers() => Context.Users.ToList();
    }
}
