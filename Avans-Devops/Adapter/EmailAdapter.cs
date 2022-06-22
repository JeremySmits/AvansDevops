using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Adapter
{
    public class EmailAdapter: IAdapter
    {
		public void SendMessage(string Address, string Message)
		{
            Console.Write("I am pretending to send a notification using e-mail here!");
			NotificationsMock.StoreNotification(Address, Message, NotificationType.Email);
		}
	}
}
