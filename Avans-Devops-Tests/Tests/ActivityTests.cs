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
            Backlog backlog = new(1, "", "");            
            InActivateSprint sprint = new(1, backlog, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new User(1,"ScrumMaster",Roles.ScrumMaster,"Scrum@Master.com"));
            backlog.AddSprint(sprint);
            BacklogItem BacklogItem = new(1, backlog, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = sprint;

            //Act
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");

            Activity Activity = new("Riem pakken", user, 1, 3);
            Activity Activity2 = new("Hond zoeken", user, 1, 3);
            BacklogItem.AddActivity(Activity);
            BacklogItem.AddActivity(Activity2);

            //Assert
            Assert.True(BacklogItem.Activities.Count == 2);
        }
        [Fact]
        public void AddActivityToBacklogWithNotStartedSprint()
        {
            //Arrange
            User ScrumUser = new(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com");
            Backlog backlog = new(1, "", "");
            InActivateSprint sprint = new(1, backlog, "Sprint 1", DateTime.Today, DateTime.Today.AddDays(1), "Type 1", ScrumUser);
            backlog.AddSprint(sprint);
            BacklogItem BacklogItem = new(1, backlog, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = sprint;

            //Act
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");
            Activity Activity = new("Riem pakken", user, 1, 2);
            Activity Activity2 = new("Hond zoeken", user, 1, 2);
            BacklogItem.AddActivity(Activity);
            BacklogItem.AddActivity(Activity2);

            //Assert
            Assert.True(BacklogItem.Activities.Count == 0);
        }

        [Fact]
        public void AddUserToActivity()
        {
            //Arrange
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");

            //Act

            Activity Activity = new("Riem pakken", user, 1);

            //Assert
            Assert.True(Activity.ResponsibleDeveloper == user);
        }
    }
}
