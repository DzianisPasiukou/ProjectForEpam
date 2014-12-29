using LogicLayer.Entities;
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

        IEnumerable<User> GetUsers();

        bool UpdateUserActive(string login, bool isActive);

        bool DeleteUser(string login);
    }
}
