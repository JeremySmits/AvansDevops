using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Avans_Devops;

namespace Avans_Devops_Tests.Tests
{
    public class ActivityTests
    {
        [Fact]
        public void AddActivityToBacklog()
        {
            //Arrange
            InActivateSprint sprint = new(1, 1, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1");
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = sprint;

            //Act
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");

            Activity Activity = new("Riem pakken", user, 1);
            Activity Activity2 = new("Hond zoeken", user, 1);
            BacklogItem.AddActivity(Activity);
            BacklogItem.AddActivity(Activity2);

            //Assert
            Assert.True(BacklogItem.Activities.Count == 2);
        }
        [Fact]
        public void AddActivityToBacklogWithNotStartedSprint()
        {
            //Arrange
            InActivateSprint sprint = new(1, 1, "Sprint 1", DateTime.Today, DateTime.Today.AddDays(1), "Type 1");
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = sprint;

            //Act
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");
            Activity Activity = new("Riem pakken", user, 1);
            Activity Activity2 = new("Hond zoeken", user, 1);
            BacklogItem.AddActivity(Activity);
            BacklogItem.AddActivity(Activity2);

            //Assert
            Assert.True(BacklogItem.Activities.Count == 0);
        }
    }
}
