using Avans_Devops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Avans_Devops_Tests.Tests
{
    public class UserTests
    {
        [Fact]
        public void ChangeUserRole()
        {
            //Arrange
            User user = new User(1, "TestUser", Roles.Developer, "Test@User.com");

            //Act
            user.ChangeRole(Roles.ProductOwner);

            //Assert
            Assert.True(user.Role == Roles.ProductOwner);
        }

        [Fact]
        public void AddOneNotificationPreference()
        {
            //Arrange
            User user = new User(1, "TestUser", Roles.Developer, "Test@User.com");

            //Act
            user.AddNotificationPreference(NotificationType.Email, user.Email);

            //Assert
            Assert.True(user.NotificationPreferences.Count == 1);
        }

        [Fact]
        public void AddMultipleNotificationPreferences()
        {
            //Arrange
            User user = new User(1, "TestUser", Roles.Developer, "Test@User.com");

            //Act
            user.AddNotificationPreference(NotificationType.Email, user.Email);
            user.AddNotificationPreference(NotificationType.Slack, "Slack test username");

            //Assert
            Assert.True(user.NotificationPreferences.Count == 2);
        }

        [Fact]
        public void RemoveOneNotificationPreference()
        {
            //Arrange
            User user = new User(1, "TestUser", Roles.Developer, "Test@User.com");

            //Act
            user.AddNotificationPreference(NotificationType.Email, user.Email);
            user.AddNotificationPreference(NotificationType.Slack, "Slack test username");

            user.RemoveNotificationPreference(NotificationType.Slack, "Slack test username");

            //Assert
            Assert.True(user.NotificationPreferences.Count == 1);
        }

        [Fact]
        public void RemoveMultipleNotificationPreferences()
        {
            //Arrange
            User user = new User(1, "TestUser", Roles.Developer, "Test@User.com");

            //Act
            user.AddNotificationPreference(NotificationType.Email, user.Email);
            user.AddNotificationPreference(NotificationType.Slack, "Slack test username");

            user.RemoveNotificationPreference(NotificationType.Email, user.Email);
            user.RemoveNotificationPreference(NotificationType.Slack, "Slack test username");

            //Assert
            Assert.True(user.NotificationPreferences.Count == 0);
        }
    }
}
