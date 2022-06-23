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

            Activity Activity = new("Riem pakken", user, BacklogItem, 3);
            Activity Activity2 = new("Hond zoeken", user, BacklogItem, 3);
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
            Activity Activity = new("Riem pakken", user, BacklogItem, 2);
            Activity Activity2 = new("Hond zoeken", user, BacklogItem, 2);
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

            Activity Activity = new("Riem pakken", user, null, 2);

            //Assert
            Assert.True(Activity.ResponsibleDeveloper == user);
        }

        [Fact]
        public void CheckIfBacklogItemisDoneWhenActivitiesAreDone()
        {
            //Arrange
            Backlog backlog = new(1, "", "");
            InActivateSprint sprint = new(1, backlog, "Sprint 1", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new User(1, "ScrumMaster", Roles.ScrumMaster, "Scrum@Master.com"));
            backlog.AddSprint(sprint);
            BacklogItem BacklogItem = new(1, backlog, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = sprint;


            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");

            Activity Activity = new("Riem pakken", user, BacklogItem, 2);
            Activity Activity1 = new("Riem on hond doen", user, BacklogItem, 2);
            Activity Activity2 = new("Deur open doen", user, BacklogItem, 2);

            BacklogItem.AddActivity(Activity);
            BacklogItem.AddActivity(Activity1);
            BacklogItem.AddActivity(Activity2);

            //Act
            BacklogItem.Activities[0].SetActvityToDone();
            BacklogItem.Activities[1].SetActvityToDone();
            BacklogItem.Activities[2].SetActvityToDone();

            //Assert
            Assert.True(BacklogItem.FinishedOn != null);
        }
    }
}
