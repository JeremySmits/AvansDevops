using Avans_Devops;
using Avans_Devops.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Avans_Devops_Tests.Tests
{
    public class BacklogItemsTests
    {
        [Fact]
        public void BacklogItemStartInToDo()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Assert
            Assert.True(BacklogItem.State == PhaseState.ToDo);
        }

        [Fact]
        public void BacklogItemFromTodoToDoing()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.Doing);
        }
        [Fact]
        public void BacklogItemFromDoingToReadyForTesting()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.ReadyForTesting);
        }


        [Fact]
        public void BacklogItemFromReadyForTestingToTesting()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");
            BacklogItem.SwitchState("Testing");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.Testing);
        }

        [Fact]
        public void BacklogItemFromTestingToTested()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = new ActiveSprint(1, null, "Sprint 1", DateTime.Today, DateTime.Now.AddDays(10), "", new User(1, "John", Roles.ScrumMaster, "John@avans.nl"));

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");
            BacklogItem.SwitchState("Testing");
            BacklogItem.SwitchState("Tested");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.Tested);
        }

        [Fact]
        public void BacklogItemFromTestingToToDo()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");
            BacklogItem.SwitchState("Testing");
            BacklogItem.SwitchState("ToDo");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.ToDo);
        }

        [Fact]
        public void BacklogItemFromTodoToDone()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Done");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.Done);
        }
        [Fact]
        public void BacklogItemFromTodoToTesting()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Testing");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.Testing);
        }
        [Fact]
        public void BacklogItemFromTodoToReadyForTesting()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("ReadyForTesting");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.ReadyForTesting);
        }
        [Fact]
        public void BacklogItemFromDoingToToDo()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ToDo");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.ToDo);
        }
        [Fact]
        public void BacklogItemFromDoingToDone()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("Done");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.Done);
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

    }
}
