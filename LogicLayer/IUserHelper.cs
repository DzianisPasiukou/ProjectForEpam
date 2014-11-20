using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer
{
    public interface IUserHelper
    {
        bool RegisterUser(string login, string password, string email, string name, string surname,string avatar);

        bool LoginUser(string login, string password);

    }
}
