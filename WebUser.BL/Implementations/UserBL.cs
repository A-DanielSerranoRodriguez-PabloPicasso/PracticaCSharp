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
        public IUserDAL userDAL { get; set; }
        public IMapper mapper { get; set; }
        public UserBL(IUserDAL userDAL, IMapper mapper)
        {
            this.userDAL = userDAL;
            this.mapper = mapper;
        }

        public bool Login(LoginDTO user)
        {
            return (userDAL.Login(mapper.Map<User>(user)));
        }

        public bool Register(UserDTO user)
        {
            return (userDAL.Register(mapper.Map<User>(user)));
        }
        public List<UserDTO> GetUsers() => mapper.Map<List<UserDTO>>(userDAL.GetUsers());

    }
}
