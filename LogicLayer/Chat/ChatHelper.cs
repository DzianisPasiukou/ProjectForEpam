using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Chat
{
    public class ChatHelper : IChatHelper
    {
        public ChatHelper()
        {

        }
        public bool AddMessage(string senderLogin, string recipientLogin, string text, string date)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Messages.Add(new Message() { Login_Sender = senderLogin, Login_Recipient = recipientLogin, Text = text, Date = date, IsRead = false });
            }
        }

        public IEnumerable<Message> GetMessages(string senderLogin, string recepientLogin)
        {
            using (DBEntities db = new DBEntities())
            {
                List<Message> sendermessages = (from message in db.Messages
                                                where message.Login_Sender.Equals(senderLogin) && message.Login_Recipient.Equals(recepientLogin)
                                                select message).ToList<Message>();


                List<Message> recmessages = (from message in db.Messages
                                             where message.Login_Sender.Equals(recepientLogin) && message.Login_Recipient.Equals(senderLogin)
                                             select message).ToList<Message>();
                foreach (var item in recmessages)
                {
                    sendermessages.Add(item);
                }

                sendermessages.Sort();
                //if (messages.Count > 15)
                //{
                //    messages.RemoveRange(0, messages.Count - 15);
                //}

                return sendermessages;
            }
        }


        public IEnumerable<string[]> GetContacts(string login)
        {
            using (DBEntities db = new DBEntities())
            {
                List<string> usersLogin = new List<string>();
                foreach (var item in db.Contacts)
                {
                    if (item.Login.Equals(login))
                    {
                        usersLogin.Add(item.User_Login);
                    }
                }

                if (usersLogin.Count == 0)
                {
                    return null;
                }

                List<string[]> contacts = new List<string[]>();

                foreach (var item in db.Users)
                {
                    if (usersLogin.Contains<string>(item.Login))
                    {
                        contacts.Add(new string[] { item.Login, item.AvatarPath });
                    }
                }

                return contacts;
            }
        }


        public string[] AddContact(string login, string userLogin)
        {
            using (DBEntities db = new DBEntities())
            {
                User user = db.Users.FirstOrDefault(model => model.Login.Equals(userLogin));

                if (user == null)
                {
                    return null;
                }

                Contact contact = new Contact() { Login = login, User_Login = userLogin };

                foreach (var item in db.Contacts)
                {
                    if (item.Login.Equals(login) && item.User_Login.Equals(userLogin))
                    {
                        return null;
                    }
                }

                bool flag = db.Contacts.Add(contact);
                if (flag)
                {
                    return new string[] { user.Login, user.AvatarPath };
                }
                else
                {
                    return null;
                }
            }
        }


        public bool DeleteContact(string login, string userLogin)
        {
            bool flag = false;
            using (DBEntities db = new DBEntities())
            {
                foreach (var item in db.Contacts)
                {
                    if (item.Login.Equals(login) && item.User_Login.Equals(userLogin))
                    {
                        Contact contact = item;
                        flag = db.Contacts.Delete(contact);
                        return flag;
                    }
                }
                return flag;
            }
        }
    }
}
