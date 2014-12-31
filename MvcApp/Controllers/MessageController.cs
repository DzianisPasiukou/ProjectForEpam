using LogicLayer.Chat;
using LogicLayer.Entities;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp.Controllers
{
    public class MessageController : ApiController
    {
        private IChatHelper _chatHelper;

        public MessageController(IChatHelper chatHelper)
        {
            if (chatHelper == null)
            {
                throw new ArgumentNullException();
            }

            _chatHelper = chatHelper;
        }

        public IEnumerable<Message> GetLikeEnable(string sender, string recipient)
        {
            List<Message> messages = _chatHelper.GetMessages(sender, recipient).ToList<Message>();

            return messages;
        }

        public IEnumerable<UsersForChat> Get(string login)
        {
            List<string[]> contacts = _chatHelper.GetContacts(login).ToList();

            List<UsersForChat> users = new List<UsersForChat>();

            foreach (var item in contacts)
            {
                users.Add(new UsersForChat { Login = item[0], AvatarPath = item[1] });
            }

            return users;
        }

        public UsersForChat Post(string login, string userLogin)
        {
            string[] contact = _chatHelper.AddContact(login, userLogin);

            if (contact == null)
            {
                return null;
            }

            UsersForChat userForChat = new UsersForChat { Login = contact[0], AvatarPath = contact[1] };

            return userForChat;
        }

        public bool Delete(string login, string userLogin)
        {
            return _chatHelper.DeleteContact(login, userLogin);
        }
    }
}
