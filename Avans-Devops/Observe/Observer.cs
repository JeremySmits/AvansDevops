using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Devops.Adapter;

namespace Avans_Devops.Observe
{
    public class Observer
    {
        public List<string> NotificationMemory { get; } = new List<string>();
        public User Receiver { get; set; }
        public string Message { get; set; }
        public List<IAdapter> SendMessage() {
            string notification = this.Receiver + "will get a message with " + this.Message;
            NotificationMemory.Add(notification);

            // This will be used to check if the right adapter has been used
            List<IAdapter> adaptersUsed = new List<IAdapter>();

            EmailAdapter emailAdapter = new EmailAdapter();
            SlackAdapter slackAdapter = new SlackAdapter();

            if (this.Receiver != null && this.Message != null){
                foreach (NotificationPreference notificationPreference in Receiver.NotificationPreferences)
                {
                    switch (notificationPreference.NotificationType)
                    {
                        case NotificationType.Email:
                            emailAdapter.SendMessage(notificationPreference.Address, this.Message);
                            adaptersUsed.Add(emailAdapter);
                            break;
                        case NotificationType.Slack:
                            slackAdapter.SendMessage(notificationPreference.Address, this.Message);
                            adaptersUsed.Add(slackAdapter);
                            break;
                    }
                }
            }

            Console.Write(notification);

            return adaptersUsed;
        }
    }
}
