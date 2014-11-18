using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Avatar { get; set; }

        public int RoleID { get; set; }

        public string DateOfRegistration { get; set; }

        public bool IsActive { get; set; }

        public double Downloaded { get; set; }

        public double Uploaded { get; set; }

        public int GaveLikes { get; set; }

        public int HaveLikes { get; set; }

    }
}
