using System.Collections.Generic;
namespace Avans_Devops
{
	public enum NotificationType
		{
			Email,
			Slack
		}

	public class NotificationPreference
		{
			public NotificationType NotificationType { get; set; }
			public string Address { get; set; }

			public NotificationPreference(NotificationType notificationType, string address)
				{
					this.NotificationType = notificationType;
					this.Address = address;
				}
		}
}

