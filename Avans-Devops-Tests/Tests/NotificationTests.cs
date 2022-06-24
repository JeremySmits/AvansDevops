using Avans_Devops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Devops.Observe;
using Avans_Devops.Adapter;
using Avans_Devops.Pipelines;
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

		[Fact]
        public void TestDoneMessageToScrumMaster()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);
            User user = new User(1, "John", Roles.ScrumMaster, "John@avans.nl");
            user.AddNotificationPreference(NotificationType.Email, user.Email);
            NotificationsMock.EmptyNotifications();


            BacklogItem.Sprint = new ActiveSprint(1, null, "Sprint 1", DateTime.Today, DateTime.Now.AddDays(10), "", user);
            NotificationsMock.EmptyNotifications();

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");
            BacklogItem.SwitchState("Testing");
            BacklogItem.SwitchState("Tested");
            BacklogItem.SwitchState("Done");

            //Assert
            Assert.True(NotificationsMock.NotificationStorage[0].Address == user.Email);
        }

        [Fact]
        public void NotificationOnPipelineSuccess()
        {
            //Arrange
            NotificationsMock.EmptyNotifications();

            var genericPipeline = PipelineFactory.CreatePipeline(PipelineType.Generic, "genericPipeline");

            genericPipeline.Sources.Add("Source 1");
            genericPipeline.Packages.Add("Package 1");
            genericPipeline.Builds.Add("Build 1");
            genericPipeline.Tests.Add("Test 1");
            genericPipeline.Analyses.Add("Analysis 1");
            genericPipeline.Deploys.Add("Deploy 1");
            genericPipeline.Deploys.Add("Deploy 2");
            genericPipeline.Utilities.Add("Utility 1");

			//Act
            genericPipeline.RunPipeline();

            //Assert
        }
    }
}
