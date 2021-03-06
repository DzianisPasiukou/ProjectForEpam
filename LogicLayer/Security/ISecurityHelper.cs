﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.Security
{
    public interface ISecurityHelper
    {
        bool RegisterUser(string login, string password, string email, string name, string surname, string avatar);

        LoginValidate LoginUser(string login, string password);

        User GetUser(string login);

        bool UpdateUser(string login, string name, string surname, string email, string role, bool isActive);

        string GetGroupForUser(string login);

        IEnumerable<Group> GetGroups();
    }
}
