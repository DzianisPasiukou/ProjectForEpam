using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer
{
    public interface ISecurityHelper
    {
        bool RegisterUser(string login, string password, string email, string name, string surname, string avatar);

        LoginValidate LoginUser(string login, string password);

        User GetUser(string login);

        IEnumerable <User> GetUsers();

        IEnumerable<Role> GetRoles();

        bool CheckPermission(string login);
    }
}
