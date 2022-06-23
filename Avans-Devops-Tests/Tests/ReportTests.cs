using Avans_Devops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Avans_Devops_Tests.Tests
{
    public class ReportTests
    {
        [Fact]
        public void CreateReportWithFileType()
        {
            //Arrange
			string projectName = "Test project";
			string companyName = "Test Company";
			string companyLogo = "Test Logo";
			string sprintName = "Sprint Name";
			Company company = new Company(companyName, companyLogo);
            Backlog backlog = new(1, projectName, "Test description", company);            
            InActivateSprint sprint = new(1, backlog, sprintName, DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new User(1,"ScrumMaster", Roles.ScrumMaster,"Scrum@Master.com"));
            backlog.AddSprint(sprint);
            BacklogItem BacklogItem = new(1, backlog, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = sprint;
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");
            Activity Activity = new("Riem pakken", user, 1, 3);
            Activity Activity2 = new("Hond zoeken", user, 1, 3);
            BacklogItem.AddActivity(Activity);
            BacklogItem.AddActivity(Activity2);

            //Act
			Report report = sprint.GenerateReport(FileType.pdf);

            //Assert
            Assert.True(report.FileType == FileType.pdf);
        }

        [Fact]
        public void CreateReportWithHeader()
        {
            //Arrange
			string projectName = "Test project";
			string companyName = "Test Company";
			string companyLogo = "Test Logo";
			string sprintName = "Sprint Name";
			Company company = new Company(companyName, companyLogo);
            Backlog backlog = new(1, projectName, "Test description", company);            
            InActivateSprint sprint = new(1, backlog, sprintName, DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new User(1,"ScrumMaster", Roles.ScrumMaster,"Scrum@Master.com"));
            backlog.AddSprint(sprint);
            BacklogItem BacklogItem = new(1, backlog, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = sprint;
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");
            Activity Activity = new("Riem pakken", user, 1, 3);
            Activity Activity2 = new("Hond zoeken", user, 1, 3);
            BacklogItem.AddActivity(Activity);
            BacklogItem.AddActivity(Activity2);

            //Act
			Report report = sprint.GenerateReport(FileType.pdf);

            //Assert
            Assert.True(report.Header.Count > 0);
			Assert.True(report.Header[0] == projectName);
			Assert.True(report.Header[1] == companyName);
			Assert.True(report.Header[2] == companyLogo);
        }

		[Fact]
        public void CreateReportWithFooter()
        {
            //Arrange
			string projectName = "Test project";
			string companyName = "Test Company";
			string companyLogo = "Test Logo";
			string sprintName = "Sprint Name";
			Company company = new Company(companyName, companyLogo);
            Backlog backlog = new(1, projectName, "Test description");            
            InActivateSprint sprint = new(1, backlog, sprintName, DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new User(1,"ScrumMaster", Roles.ScrumMaster,"Scrum@Master.com"));
            backlog.AddSprint(sprint);
            BacklogItem BacklogItem = new(1, backlog, 1, "Hond Uitlaten", 1, 2);
            BacklogItem.Sprint = sprint;
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");
            Activity Activity = new("Riem pakken", user, 1, 3);
            Activity Activity2 = new("Hond zoeken", user, 1, 3);
            BacklogItem.AddActivity(Activity);
            BacklogItem.AddActivity(Activity2);

            //Act
			Report report = sprint.GenerateReport(FileType.pdf);

            //Assert
            Assert.True(report.Footer.Count > 0);
			Assert.True(report.Footer[0] == sprintName);
			Assert.True(report.Footer[1] == sprint.StartDate + " - " + sprint.EndDate);
        }

		[Fact]
        public void GenerateBurnDownChart()
        {
            //Arrange
			string projectName = "Test project";
			string companyName = "Test Company";
			string companyLogo = "Test Logo";
			string sprintName = "Sprint Name";
			Company company = new Company(companyName, companyLogo);
            Backlog backlog = new(1, projectName, "Test description");            
            InActivateSprint sprint = new(1, backlog, sprintName, DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new User(1,"ScrumMaster", Roles.ScrumMaster,"Scrum@Master.com"));
            backlog.AddSprint(sprint);

            BacklogItem BacklogItem1 = new(1, backlog, 1, "Hond Uitlaten", 1, 2);
			sprint.AddBacklogItem(BacklogItem1);
            backlog.AddBacklogItem(BacklogItem1);

			BacklogItem1.SwitchState("Doing");
			BacklogItem1.SwitchState("ReadyForTesting");
			BacklogItem1.SwitchState("Testing");
			BacklogItem1.SwitchState("Done");

            BacklogItem BacklogItem2 = new(1, backlog, 1, "Hond Uitlaten 2", 1, 2);
			sprint.AddBacklogItem(BacklogItem2);
            backlog.AddBacklogItem(BacklogItem2);

			BacklogItem2.SwitchState("Doing");
			BacklogItem2.SwitchState("ReadyForTesting");
			BacklogItem2.SwitchState("Testing");
			BacklogItem2.SwitchState("Done");

            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");
            Activity Activity = new("Riem pakken", user, 1, 1);
            Activity Activity2 = new("Hond zoeken", user, 1, 1);
            BacklogItem1.AddActivity(Activity);
            BacklogItem1.AddActivity(Activity2);

            //Act
			Report report = sprint.GenerateReport(FileType.pdf);

            //Assert
            Assert.True(report.BurnDownChart.Count > 0);
			Assert.True(report.BurnDownChart[BacklogItem1.FinishedOn] == 4);
        }

		[Fact]
        public void GenerateDeveloperEffortValues()
        {
            //Arrange
			string projectName = "Test project";
			string companyName = "Test Company";
			string companyLogo = "Test Logo";
			string sprintName = "Sprint Name";
			Company company = new Company(companyName, companyLogo);
            Backlog backlog = new(1, projectName, "Test description");            
            ActiveSprint sprint = new(1, backlog, sprintName, DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new User(1,"ScrumMaster", Roles.ScrumMaster,"Scrum@Master.com"));
            backlog.AddSprint(sprint);

            BacklogItem BacklogItem1 = new(1, backlog, 1, "Hond Uitlaten", 1, 2);
			sprint.AddBacklogItem(BacklogItem1);

            BacklogItem BacklogItem2 = new(1, backlog, 1, "Hond Uitlaten 2", 1, 2);
			sprint.AddBacklogItem(BacklogItem2);

            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");
            Activity Activity = new("Riem pakken", user, 1, 1);
			Activity.State = PhaseState.Done;
            Activity Activity2 = new("Hond zoeken", user, 1, 1);
			Activity2.State = PhaseState.Done;
            BacklogItem1.AddActivity(Activity);
            BacklogItem1.AddActivity(Activity2);

			User user2 = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");
			Activity Activity3 = new("Riem pakken", user2, 1, 2);
			Activity3.State = PhaseState.Done;
            Activity Activity4 = new("Hond zoeken", user2, 1, 2);
			Activity4.State = PhaseState.Done;
            BacklogItem2.AddActivity(Activity3);
            BacklogItem2.AddActivity(Activity4);

            BacklogItem1.SwitchState("Doing");
			BacklogItem1.SwitchState("ReadyForTesting");
			BacklogItem1.SwitchState("Testing");
			BacklogItem1.SwitchState("Done");

            
			BacklogItem2.SwitchState("Doing");
			BacklogItem2.SwitchState("ReadyForTesting");
			BacklogItem2.SwitchState("Testing");
			BacklogItem2.SwitchState("Done");

            //Act
			Report report = sprint.GenerateReport(FileType.pdf);

            //Assert
            // Assert.True(report.DeveloperEffortValues.Count == 0);
			Assert.True(report.DeveloperEffortValues.Count == 0);
        }
    }
}
