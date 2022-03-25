﻿using Avans_Devops;
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
            Sprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(10), "Type 1", new ActivateSprintState());
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
            Sprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new ActivateSprintState());
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);


            //Act
            sprint.AddBacklogItem(BacklogItem);

            //Assert
            Assert.True(sprint.BacklogItems.Count == 1);
        }
    }
}