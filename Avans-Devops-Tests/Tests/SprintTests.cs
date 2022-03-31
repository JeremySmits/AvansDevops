using Avans_Devops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Avans_Devops_Tests.Tests
{
    public class SprintTests
    {
        [Fact]
        public void AddToBacklogItemToActiveSprint()
        {
            //Arrange
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            InActivateSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), "Type 1", user);
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);


            //Act
            sprint.AddBacklogItem(BacklogItem);

            //Assert
            Assert.True(sprint.BacklogItems.Count == 0);
        }

        [Fact]
        public void AddToBacklogItemToNewSprint()
        {
            //Arrange
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            InActivateSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", user);
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);


            //Act
            sprint.AddBacklogItem(BacklogItem);

            //Assert
            Assert.True(sprint.BacklogItems.Count == 1);
        }

        [Fact]
        public void CheckIfSprintHasScrumMaster()
        {
            //Arrange
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            InActivateSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", user);

            //Assert
            Assert.True(sprint.ScrumMaster != null);
        }

        [Fact]
        public void SetSprintstate()
        {
            //Arrange
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            Sprint sprint = new InActivateSprint(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", user);

            //Act
            sprint = new ActiveSprint(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", user);

            var s = sprint.GetTypeSprint();

            //Assert
            Assert.True(sprint.GetTypeSprint() == "Active");
        }
    }
}
