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
        public User? GetUser(string username)
        {
            return Context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public List<User> GetUsers() => Context.Users.ToList();

        public bool DeleteUser(string username)
        {
            User? found = GetUser(username);
            if (found != null)
            {
                Context.Remove(found);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateUser(string username, User user)
        {
            User? found = GetUser(username);
            if(found != null)
            {
                if (user.UserName.Length > 0)
                    found.Password = user.Password;
                if (user.UserName.Length > 0)
                    found.Email = user.Email;
                if (user.UserName.Length > 0)
                    found.BirthDate = user.BirthDate;
                Context.Users.Update(found);
                Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
