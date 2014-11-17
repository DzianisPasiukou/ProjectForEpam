using DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IDatabaseHelper
    {
        bool RegisterUser(string login, string password, string email, string name, string surname,string avatar);

        User LoginUser(string login, string password);

    }
}
