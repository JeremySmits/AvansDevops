using Avans_Devops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Devops.Observe;
using Avans_Devops.Adapter;
using Xunit;

namespace Avans_Devops_Tests.Tests
{
    public class NotificationTests
    {
        [Fact]
        public void UseEmailAdapter()
        {
            //Arrange
			NotificationsMock.EmptyNotifications();

            User user = new(1, "TestUser", Roles.Developer, "Test@User.com");
			user.AddNotificationPreference(NotificationType.Email, user.Email);

			Observer observer = new();
			observer.Receiver = user;
			string message = "This is a test message!";
			observer.Message = message;

            //Act
			observer.SendMessage();

            //Assert
            Assert.True(NotificationsMock.NotificationStorage[0].Address == user.Email);
			Assert.True(NotificationsMock.NotificationStorage[0].Message == message);
			Assert.True(NotificationsMock.NotificationStorage[0].NotificationType == NotificationType.Email);
        }

		[Fact]
        public void UseSlackAdapter()
        {
            //Arrange
			NotificationsMock.EmptyNotifications();

            User user = new(1, "TestUser", Roles.Developer, "Test@User.com");
			string slackAddress = "Slack test username";
            user.AddNotificationPreference(NotificationType.Slack, slackAddress);

			Observer observer = new();
			observer.Receiver = user;
			string message = "This is a test message!";
			observer.Message = message;

            //Act
			observer.SendMessage();

            //Assert
            Assert.True(NotificationsMock.NotificationStorage[0].Address == slackAddress);
			Assert.True(NotificationsMock.NotificationStorage[0].Message == message);
			Assert.True(NotificationsMock.NotificationStorage[0].NotificationType == NotificationType.Slack);
        }


	    [Fact]
        public void UseMultipleAdapters()
        {
            //Arrange
			NotificationsMock.EmptyNotifications();

            User user = new(1, "TestUser", Roles.Developer, "Test@User.com");
			user.AddNotificationPreference(NotificationType.Email, user.Email);
			string slackAddress = "Slack test username";
            user.AddNotificationPreference(NotificationType.Slack, slackAddress);

			Observer observer = new();
			observer.Receiver = user;
			string message = "This is a test message!";
			observer.Message = message;

            //Act
			observer.SendMessage();

            //Assert
			Assert.True(NotificationsMock.NotificationStorage[0].Address == user.Email);
			Assert.True(NotificationsMock.NotificationStorage[0].Message == message);
			Assert.True(NotificationsMock.NotificationStorage[0].NotificationType == NotificationType.Email);
            Assert.True(NotificationsMock.NotificationStorage[1].Address == slackAddress);
			Assert.True(NotificationsMock.NotificationStorage[1].Message == message);
			Assert.True(NotificationsMock.NotificationStorage[1].NotificationType == NotificationType.Slack);
        }
    }
}
