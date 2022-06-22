using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Adapter
{
    public class SlackAdapter : IAdapter
    {
        public void SendMessage(string Address, string Message)
        {
            Console.Write("I am pretending to send a notification using slack here!");
			NotificationsMock.StoreNotification(Address, Message, NotificationType.Slack);
        }
    }
}
