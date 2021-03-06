﻿using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Users
{
    public interface IUserHelper
    {
        bool UpdateUser(string login, string name, string surname, string email, string group);

        User GetUser(string login);

        IEnumerable<User> GetUsers();

        IEnumerable<Group> GetGroups();

        bool UpdateUserActive(string login, bool isActive);

        bool DeleteUser(string login);
    }
}
