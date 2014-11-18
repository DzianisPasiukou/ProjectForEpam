using DataBaseLayer;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer
{
    public class DatabaseHelper : IDatabaseHelper
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
            using (DBEntities entity = new DBEntities())
            {
                return entity.User.Add(new User
                {
                    Login = login,
                    Password = password,
                    Email = email,
                    IsActive = false,
                    Name = name,
                    Surname = surname,
                    DateOfRegistration = DateTime.Now.ToShortDateString(),
                    RoleID = 1,
                    Avatar = avatar
                });
            }
        }

        public bool LoginUser(string login, string password)
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

            using (DBEntities entity = new DBEntities())
            {
                DBSet<User> users = entity.User;

                foreach (var item in users)
                {
                    if (item.Login.Equals(login))
                    {
                        user = item;
                    }
                }

                return user != null && user.Password.Equals(password);
            }
        }
    }
}
