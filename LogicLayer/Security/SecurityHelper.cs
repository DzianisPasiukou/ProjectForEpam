﻿using DataBaseLayer;
using LogicLayer.Entities;
using LogicLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer.Security
{
    public enum LoginValidate
    {
        Seccess,
        NotApproved,
        NotRegistered
    }

    public class SecurityHelper : ISecurityHelper
    {
        IHashCalculator _hashCalculator;

        public SecurityHelper()
        {
            
        }

        public SecurityHelper(IHashCalculator hashCalculator)
        {
            if (hashCalculator == null)
            {
                throw new ArgumentNullException("HashCalculator");
            }

            _hashCalculator = hashCalculator;
        }

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
                avatar = "/Resourse/Images/AdminAvatar.jpg";
            }

            using (DBEntities db = new DBEntities())
            {
                if (db.Users.FirstOrDefault(user => user.Login.Equals(login)) != null)
                {
                    return false;
                }

                //TODO: check id_group, check avatarpath for user adding.

                return db.Users.Add(new User
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Login = login,
                    Password = _hashCalculator.Calculate(password),
                    AvatarPath = avatar,
                    DateOfRegistration = DateTime.Now,
                    IsActive = false,
                    Id_Group = 2
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

            User user;
            using (DBEntities db = new DBEntities())
            {
                user = db.Users.SingleOrDefault(u => u.Login.Equals(login));
            }

            if (user != null)
            {
                if (user.IsActive == true)
                {
                    return LoginValidate.Seccess;
                }
                else
                {
                    return LoginValidate.NotApproved;
                }
            }

            return LoginValidate.NotRegistered;
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
                return db.Users;
            }
        }

        public bool UpdateUser(string login, string name, string surname, string email, string role, bool isActive)
        {
            throw new NotImplementedException();
        }

        public string GetGroupForUser(string login)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Groups.First(group => group.Id_Group.Equals(db.Users.First(user => user.Login.Equals(login)).Id_Group)).Name;
            }
        }
        public bool AddMessage(string senderLogin, string recipientLogin, string text, string date)
        {
            int sender, recipient;
            using (DBEntities db = new DBEntities())
            {
                sender = db.Users.First(user => user.Login.Equals(senderLogin)).Id_User;
                recipient = db.Users.First(user => user.Login.Equals(recipientLogin)).Id_User;
                return db.Messages.Add(new Message() {Id_Sender = sender, Id_Recipient = recipient, Text = text, Date = date, IsRead = false });              
            }
        }

        public IEnumerable<Task> GetTasks()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Tasks.ToList();
            }
        }


        public IEnumerable<Adapter> GetAdapters()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Adapters.ToList();
            }
        }


    }
}
