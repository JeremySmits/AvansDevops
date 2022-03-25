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
            InActivateSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), "Type 1");
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
            InActivateSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1");
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);


            //Act
            sprint.AddBacklogItem(BacklogItem);

            //Assert
            Assert.True(sprint.BacklogItems.Count == 1);
        }

        [Fact]
        public void SetSprintstate()
        {
            //Arrange
            InActivateSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1");


            //Act

            //Assert
            //Assert.True(sprint.SprintState.BacklogItemsAdd);
        }
    }
}
