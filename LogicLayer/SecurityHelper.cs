using DataBaseLayer;
using LogicLayer.Entities;
using System;
using System.Collections.Generic;
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

                DBSet<User> users = db.Users;

                foreach (var item in users)
                {
                    if (item.Login.Equals(login))
                    {
                        return false;
                    }
                }

                //TODO: check id_group, check avatarpath for user adding.

                return db.Users.Add(new User
                {
                    Login = login,
                    Password = password,
                    Email = email,
                    IsActive = false,
                    Name = name,
                    Surname = surname,
                    DateOfRegistration = DateTime.Now,
                    Id_Group = 1,
                    AvatarPath = avatar
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
                DBSet<User> users = db.Users;

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
                return db.Users.FirstOrDefault(user => user.Login == login);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (DBEntities db = new DBEntities())
            {
                IEnumerable<User> users = db.Users;
                return users;
            }
        }

        public IEnumerable<Group> GetRoles()
        {
            using (DBEntities db = new DBEntities())
            {
                IEnumerable<Group> roles = db.Groups;
                return roles;
            }
        }

        public bool CheckPermission(string login)
        {
            throw new NotImplementedException();
        }
    }
}
