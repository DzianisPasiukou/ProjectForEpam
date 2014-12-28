using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
    public class User
    {
        public int Id_User { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string AvatarPath { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public bool IsActive { get; set; }

        public int Id_Group { get; set; }
    }
}
