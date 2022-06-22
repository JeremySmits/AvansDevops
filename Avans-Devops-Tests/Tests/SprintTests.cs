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
            ActiveSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), "Type 1", user);
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);


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
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);


            //Act
            sprint.AddBacklogItem(BacklogItem);

            //Assert
            Assert.True(sprint.BacklogItems.Count == 1);
        }

        [Fact]
        public void AddToBacklogItemToFinishedSprint()
        {
            //Arrange
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            FinishedSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), "Type 1", user);
            BacklogItem BacklogItem = new(1, null, 1, "Hond Uitlaten", 1, 2);


            //Act
            sprint.AddBacklogItem(BacklogItem);

            //Assert
            Assert.True(sprint.BacklogItems.Count == 0);
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
        public void SetSprintstateInActive()
        {
            //Arrange
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            Sprint sprint;

            //Act
            sprint = new InActivateSprint(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", user);

            //Assert
            Assert.True(sprint.GetTypeSprint() == "Inactive");
        }

        [Fact]
        public void SetSprintstateFinishedActive()
        {
            //Arrange
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            Sprint sprint;

            //Act
            sprint = new FinishedSprint(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", user);


            //Assert
            Assert.True(sprint.GetTypeSprint() == "Finished");
        }

        [Fact]
        public void SetSprintToFinishedWhenPipelineSucces()
        {
            //Arrange
            Backlog backlog = new(1, "Avans Devops", "SO&A uitwerking", null);

            //Act
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            backlog.AddSprint(new ActiveSprint(1, 1, "Sprint 1", DateTime.Today, DateTime.Today.AddDays(1), "Type 1", user));

            //Assert
            Assert.True(backlog.RunSprintDeployment(backlog.Sprints[0],1) && backlog.Sprints[0].GetTypeSprint() == "Finished");
        }

        [Fact]
        public void SetSprintNotToFinishedWhenPipelineFail()
        {
            //Arrange
            Backlog backlog = new(1, "Avans Devops", "SO&A uitwerking", null);

            //Act
            User user = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            backlog.AddSprint(new ActiveSprint(1, 1, "Sprint 1", DateTime.Today, DateTime.Today.AddDays(1), "Type 1", user));

            //Assert
            Assert.True(!backlog.RunSprintDeployment(backlog.Sprints[0], 9) && backlog.Sprints[0].GetTypeSprint() == "Active");
        }
    }
}
