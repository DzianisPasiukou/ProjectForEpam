using DataBaseLayer;
using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public enum LoginValidate
    {
        Seccess,
        NotApproved,
        NotRegistered
    }

    public class SecurityHelper : ISecurityHelper
    {
        public bool RegisterUser(string login, string password, string email, string name, string surname, string avatar)
        {
            if (String.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException("login");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }
            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if (String.IsNullOrEmpty(surname))
            {
                throw new ArgumentNullException("surname");
            }
            if (String.IsNullOrEmpty(avatar))
            {
                avatar = "defAVATARPath";
            }

            using (DBEntities db = new DBEntities())
            {
                User user = new User();

                DBSet<User> users = db.User;

                foreach (var item in users)
                {
                    if (item.Login.Equals(login))
                    {
                        return false;
                    }
                }

                return db.User.Add(new User
                {
                    Login = login,
                    Password = password,
                    Email = email,
                    IsActive = false,
                    Name = name,
                    Surname = surname,
                    DateOfRegistration = DateTime.Now.ToString(),
                    RoleID = 3,
                    Avatar = avatar
                });
            }
        }

        public LoginValidate LoginUser(string login, string password)
        {
            if (String.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException("login");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            User user = new User();

            using (DBEntities db = new DBEntities())
            {
                DBSet<User> users = db.User;

                foreach (var item in users)
                {
                    if (item.Login.Equals(login))
                    {
                        user = item;
                        if (user != null && user.Password.Equals(password) && user.IsActive)
                        {
                            return LoginValidate.Seccess;
                        }
                        else
                        {
                            return LoginValidate.NotApproved;
                        }
                    }
                }

                return LoginValidate.NotRegistered;
            }
        }


        public User GetUser(string login)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.User.FirstOrDefault(user => user.Login == login);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (DBEntities db = new DBEntities())
            {
                List<User> users = db.User.ToList<User>();

                return users;
            }
        }

        public string GetRole(string login)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Role.FirstOrDefault(role => role.ID == db.User.FirstOrDefault(user => user.Login.Equals(login)).RoleID).Name;
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Role.ToList<Role>();
            }
        }

        public bool UpdateUser(string login, string name, string surname, string email, string role, bool isActive)
        {
            using (DBEntities db = new DBEntities())
            {
                User user = db.User.FirstOrDefault(model => model.Login == login);

                user.Name = name;
                user.Surname = surname;
                user.Email = email;
                user.RoleID = db.Role.FirstOrDefault(rol => rol.Name == role).ID;
                user.IsActive = isActive;

                return db.User.Update(user);
            }
        }
    }
}
