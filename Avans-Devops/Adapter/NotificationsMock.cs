using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Adapter
{
	public class Notification
	{
		public string Address { get; set; }
		public string Message { get; set; }
		public NotificationType NotificationType { get; set; }
		public Notification(string address, string message, NotificationType notificationType)
		{
			Address = address;
			Message = message;
			NotificationType = notificationType;
		}
	}

    public static class NotificationsMock
    {

		public static List<Notification> NotificationStorage { get; set; }

		static NotificationsMock() {
			NotificationStorage = new List<Notification>();
		}

		public static void StoreNotification (string Address, string Message, NotificationType notificationType)
		{
			Notification newNotification = new Notification(Address, Message, notificationType);
			NotificationStorage.Add(newNotification);
		}

		public static void EmptyNotifications ()
		{
			NotificationStorage = new List<Notification>();
		}



    }
}
