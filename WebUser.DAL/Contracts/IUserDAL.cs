﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUser.DAL.Tables;

namespace WebUser.DAL.Contracts
{
    public interface IUserDAL
    {
        public bool Login(User user);
        public bool Register(User user);
        public List<User> GetUsers();
    }
}
