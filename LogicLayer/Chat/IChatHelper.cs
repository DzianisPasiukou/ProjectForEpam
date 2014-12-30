using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Chat
{
    public interface IChatHelper
    {
        bool AddMessage(string senderLogin, string recipientLogin, string text, string date);

        IEnumerable<Message> GetMessages(string senderLogin, string recipientLogin);

        IEnumerable<string []> GetContacts(string login);
    }
}
