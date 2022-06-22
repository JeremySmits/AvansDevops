using System.Collections.Generic;
namespace Avans_Devops
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Roles Role { get; set; }
        public string Email { get; set; }
        public List<NotificationPreference> NotificationPreferences { get; set; }

        public User(int userId, string name, Roles role, string email)
        {
            this.UserId = userId;
            this.Name = name;
            this.Role = role;
            this.Email = email;
            this.NotificationPreferences = new List<NotificationPreference>();
        }

        public void ChangeRole(Roles role) 
        {
            this.Role = role;
        }

        public void AddNotificationPreference(NotificationType notificationType, string address)
        {
            NotificationPreference newNotificationPreference = new NotificationPreference(notificationType, address);
            this.NotificationPreferences.Add(newNotificationPreference);
        }

        public bool RemoveNotificationPreference(NotificationType notificationType, string address)
        {
            foreach (NotificationPreference notificationPreference in NotificationPreferences) {
                if (notificationPreference.NotificationType == notificationType && notificationPreference.Address == address)
                {
                    return this.NotificationPreferences.Remove(notificationPreference);
                }
            }

            return false;
        }

        public void Notify() { }
    }
}