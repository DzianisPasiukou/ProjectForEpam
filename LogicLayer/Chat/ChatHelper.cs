using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Chat
{
   public class ChatHelper:IChatHelper
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
                List<Message> messages = (from message in db.Messages
                                          where message.Login_Sender.Equals(senderLogin) && message.Login_Recipient.Equals(recepientLogin)
                                          select message).ToList<Message>();

                messages.OrderBy(x => x.Date);

                if (messages.Count > 15)
                {
                    messages.RemoveRange(0, messages.Count - 15);
                }

                return messages;
            }            
        }
    }
}
