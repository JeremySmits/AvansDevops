using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Observe
{
    public class Observer
    {
        public List<string> NotificationMemory { get; } = new List<string>();
        public User Receiver { get; set; }
        public string Message { get; set; }
        public void SendMessage(User Receiver, string Message) {
            string notification = Receiver + "will get a message with " + Message;
            NotificationMemory.Add(notification);
            Console.Write(notification);
        }
    }
}
