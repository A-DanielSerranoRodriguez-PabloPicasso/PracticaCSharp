using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUser.BL.Contracts;
using WebUser.Core.DTO;
using WebUser.DAL.Contracts;
using WebUser.DAL.Tables;

namespace WebUser.BL.Implementations
{
    public class UserBL : IUserBL
    {
        public IUserDAL UserDAL { get; set; }
        public IMapper Mapper { get; set; }
        public UserBL(IUserDAL userDAL, IMapper mapper)
        {
            this.UserDAL = userDAL;
            this.Mapper = mapper;
        }

        public bool Login(LoginDTO user)
        {
            return (UserDAL.Login(Mapper.Map<User>(user)));
        }

        public bool Register(UserDTO user)
        {
            return UserDAL.Register(Mapper.Map<User>(user));
        }

        public List<UserDTO> GetUsers() => Mapper.Map<List<UserDTO>>(UserDAL.GetUsers());

        public bool DeleteUser(string username)
        {
            return UserDAL.DeleteUser(username);
        }
    }
}
