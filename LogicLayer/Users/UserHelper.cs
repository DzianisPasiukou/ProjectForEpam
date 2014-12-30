using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Users
{
    public class UserHelper : IUserHelper
    {
        public bool UpdateUser(string login, string name, string surname, string email, string group)
        {
            using (DBEntities db = new DBEntities())
            {
                User user = db.Users.First(model => model.Login.Equals(login));
                user.Name = name;
                user.Surname = surname;
                user.Email = email;
                user.Id_Group = db.Groups.First(model => model.Name.Equals(group)).Id_Group;

                bool flag = db.Users.Update(user);
                return flag;
            }
        }

        public User GetUser(string login)
        {
            using (DBEntities db = new DBEntities())
            {
                User user = db.Users.First(model => model.Login.Equals(login));
                return user;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Users.ToList();
            }
        }


        public IEnumerable<Group> GetGroups()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Groups.ToList();
            }
        }

        public bool UpdateUserActive(string login, bool isActive)
        {
            using (DBEntities db = new DBEntities())
            {
                User user = db.Users.First(model => model.Login.Equals(login));
                user.IsActive = isActive;
                bool flag = db.Users.Update(user);
                return flag;
            }
        }


        public bool DeleteUser(string login)
        {
            using (DBEntities db = new DBEntities())
            {
                User user = db.Users.First(model => model.Login.Equals(login));

                bool flag = db.Users.Delete(user);
                return flag;
            }
        }
    }
}
