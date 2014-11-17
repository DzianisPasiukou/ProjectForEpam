using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper helper = new DatabaseHelper();

            bool flag = helper.RegisterUser("def", "123", "lol@gmail.com", "defname", "defsurname", "");
            Console.WriteLine(flag);
        }
    }
}
